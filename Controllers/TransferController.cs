using Microsoft.AspNetCore.Mvc;
using LibraryApi.Models;
using LibraryApi.Data;

namespace LibraryApi.Controllers;

[ApiController]
[Route("api/transfer")]
public class TransferController : ControllerBase
{
    [HttpPost]
    public IActionResult Transfer(TransferRequest request)
    {
        if (request.Amount <= 0)
        {
            return BadRequest(new { status = "Failed", error = "InvalidAmount" });
        }

        var from = LibraryStore.Members.FirstOrDefault(x => x.Id == request.FromId);
        var to = LibraryStore.Members.FirstOrDefault(x => x.Id == request.ToId);

        if (from == null || to == null)
        {
            return BadRequest(new { status = "Failed", error = "AccountNotFound" });
        }

        if (from.Balance < request.Amount)
        {
            return BadRequest(new { status = "Failed", error = "InsufficientFunds" });
        }

        from.Balance -= request.Amount;
        to.Balance += request.Amount;

        return Ok(new { status = "Success" });
    }
}