using Library.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Entities.Concreate
{
    public class SubCategory : ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public int CategoryId { get; set; }
        public Category Category { get; set; }


        public List<Book> Books { get; set; }
    }
}
