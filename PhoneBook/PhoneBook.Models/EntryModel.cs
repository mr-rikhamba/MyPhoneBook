using System;
namespace PhoneBook.Models
{
    public class EntryOutputModel: EntryInputModel
    {
        public int EntryId { get; set; }
        public PhoneBookOutputModel PhoneBook { get; set; }
    }

    public class EntryInputModel
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneBookId { get; set; }
    }
}
