using System;
namespace PhoneBook.Models
{
    public class EntryModel:BaseModel
    {
        public int EntryId { get; set; }
        public int PhoneBookId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public PhoneBookOutputModel PhoneBook { get; set; }
    }
}
