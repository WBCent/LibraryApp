using System.Text;
using Xunit;
using LibraryApp.Controllers.BookControllers;
using Microsoft.AspNetCore.Mvc.Testing;

namespace LibraryApp.Tests.ApiEndpoints
{
    //The IClassFixture<WebApplicationFactory<Program>> writing creates an in memory test server, allowing you to host your API in a test environment.
    public class AddBookTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly Type[] _types;
        
        private readonly HttpClient _client;

        public AddBookTests(WebApplicationFactory<Type> factory)
        {
            _types = typeof(AddBookController).Assembly.GetTypes();
            _client = factory.CreateClient();
        }

        //Fact: marks a test method
        [Fact]
        public async Task AddBook_ShouldAddBookToDB()
        {
            //Arrange: where we arrange the values, and get things setup to run test
            //This is the expected value we want at the end of it.
            Object expected = new
            {
                Title = "Harry Potter",
                Author = "Rowling",
                ISBN = 123456,
                Genre = "Fantasy",
                Description = "Wands",
                Available = true
            };

            var uri = new Uri("/api/AddBook/AddBook");
            var body = new StringContent(expected.ToString(), Encoding.UTF8, "application/json");

            //Act: where you do the action that we are testing
            var response = await _client.PostAsync(uri, body);

            //Assertion: this is what I expect here is the actual value.
            response.EnsureSuccessStatusCode();
            response.Content.Equals(body);
        }

    }
}