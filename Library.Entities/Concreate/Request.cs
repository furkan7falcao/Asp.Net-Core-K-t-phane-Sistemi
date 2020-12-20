using Library.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Entities.Concreate
{
    public class Request : ITable
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }

        public int ReceiverMemberId { get; set; } = 1;

        public int PosterMemberId { get; set; }
        public Member PosterMember { get; set; }

        public int WantedBookId { get; set; }
        public Book WantedBook { get; set; }
    }
}
