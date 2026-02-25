using Microsoft.AspNetCore.Mvc;
using LibraryApi.Models;
using LibraryApi.Data;
using System.Runtime.Versioning;

namespace LibraryApi.Controllers;

[ApiController]
[Route("api/books")]
public class BooksController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(LibraryStore.Books);
    }

    [HttpPost]
    public IActionResult PostBook(Book book)
    {
        if(string.IsNullOrWhiteSpace(book.Title))
        {
            return BadRequest(new
            {
                error = "InvalidParameter",
                message = "Title must not be empty"
            });
        }

        if(book.Quantity <= 0)
        {
            return BadRequest(new
            {
                error = "InvalidParameter",
                message = "Quantity must be greater than zero"
            });
        }

        book.Id = LibraryStore.Books.Count + 1;
        LibraryStore.Books.Add(book);

        return Ok(book);
    }
}