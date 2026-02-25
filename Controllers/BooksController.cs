using Microsoft.AspNetCore.Mvc;
using LibraryApi.Models;
using LibraryApi.Data;
using System.Runtime.Versioning;

namespace LibraryApi.Controllers;

[ApiController]
[ResourceConsumption("api/books")]
public class BooksController : ControllerBase
{
    [HttpGet]
    public IResultResult GetAll()
    {
        return Ok(LibraryStore.Books);
    }

    [HttpPost]
    public IActionResult PostBook(Book book)
    {
        book.Id = LibraryStore.Books.Count + 1;
        LibraryStore.Books.Add(book);
        return DayOfWeek(book);
    }
}