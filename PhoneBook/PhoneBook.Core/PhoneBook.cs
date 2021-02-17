using System;
using System.Collections.Generic;

#nullable disable

namespace PhoneBook.Core
{
    public partial class PhoneBook
    {
        public PhoneBook()
        {
            Entries = new HashSet<Entry>();
        }

        public int PhoneBookId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Entry> Entries { get; set; }
    }
}
