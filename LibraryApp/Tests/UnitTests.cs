using System.Text;
using Xunit;
using Xunit.Abstractions;
using JsonSerializer = System.Text.Json.JsonSerializer;
using Microsoft.AspNetCore.Mvc.Testing;

namespace TestProject1
{
    //The IClassFixture<WebApplicationFactory<Program>> writing creates an in memory test server, allowing you to host your API in a test environment.
    public class AddBookTests : IClassFixture<Program>
    {

        private readonly ITestOutputHelper _logger;

        public AddBookTests(ITestOutputHelper helper)
        {
            _logger = helper;
        }
        

        //Fact: marks a test method
        [Fact]
        public async void AddBook_ShouldAddBookToDB()
        {
            //Arrange: where we arrange the values, and get things setup to run test
            //This is the expected value we want at the end of it.
            var expected = new
            {
                Title = "Harry Potter",
                Author = "Rowling",
                ISBN = "obiubuyivuytcyc",
                Genre = "Fantasy",
                Description = "Wands",
                Available = true
            };

            await using var application = new WebApplicationFactory<Program>();
            var _client = application.CreateClient();
            var uri = new Uri("http://localhost:5229/api/AddBook/AddBook");
            var body = new StringContent(JsonSerializer.Serialize(expected), Encoding.UTF8, "application/json");

            //Act: where you do the action that we are testing
            var response = await _client.PostAsync(uri, body);
            var content = await response.Content.ReadAsStringAsync();
            
            //Assertion: this is what I expect here is the actual value.
            response.EnsureSuccessStatusCode();
            Assert.Contains("Book was Added", content);
        }

    }
}