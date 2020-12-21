using Library.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Entities.Concreate
{
    public class Member: IdentityUser<int>,ITable
    {
        public string FullName { get; set; }
        public DateTime BirthYear { get; set; }
        public string Picture { get; set; } = "default.png";

        public List<Book> Books { get; set; }
        public List<Request> Requests { get; set; }
    }
}
