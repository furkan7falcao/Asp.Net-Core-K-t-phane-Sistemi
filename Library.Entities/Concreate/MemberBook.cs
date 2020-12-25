using Library.Entities.Interfaces;

namespace Library.Entities.Concreate
{
    public class MemberBook: ITable
    {
        public int Id { get; set; }
        public bool isRead { get; set; }


        public int? MemberId { get; set; }
        public Member Member { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
