using System.ComponentModel.DataAnnotations;

namespace LibraryApp.DTOs;

public class BorrowDto
{
    public string Borrower;
    [Key]
    public string ISBN;
}