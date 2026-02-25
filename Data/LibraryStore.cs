using System.Data.Common;
using LibraryApi.Models;

namespace LibraryApi.Data;

public static class LibraryStore
{
    public static List<Book> Books = new();

    public static List<MemberBalance> Members = new()
    {
      new MemberBalance { Id = 1, Balance = 100 },
      new MemberBalance { Id = 2, Balance = 200 }
    };
}