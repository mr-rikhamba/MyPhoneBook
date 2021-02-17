using System;
using System.Collections.Generic;

#nullable disable

namespace PhoneBook.Core
{
    public partial class Entry
    {
        public int EntryId { get; set; }
        public int PhoneBookId { get; set; }
        public string Name { get; set; }

        public virtual PhoneBook PhoneBook { get; set; }
    }
}
