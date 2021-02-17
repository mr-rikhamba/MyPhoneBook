using System;
namespace PhoneBook.Models
{
    public class EntryModel
    {
        public int EntryId { get; set; }
        public int PhoneBookId { get; set; }
        public string Name { get; set; }
        public PhoneBookModel PhoneBook { get; set; }
    }
}
