using Library.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Entities.Concreate
{
    public class Author : ITable
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Nation { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }


        public List<Book> Books { get; set; }
    }
}
