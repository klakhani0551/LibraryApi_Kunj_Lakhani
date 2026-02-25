namespace LibraryApi.Models;

public class TransferRequest
{
    public int FromId {get; set; }
    public int ToId {get; set; }
    public int Amount {get; set; }
}