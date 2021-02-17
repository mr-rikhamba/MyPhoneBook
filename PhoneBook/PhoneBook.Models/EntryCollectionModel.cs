using System;
using System.Collections.Generic;

namespace PhoneBook.Models
{
    public class EntryCollectionModel : BaseModel
    {
        public List<EntryModel> Entries { get; set; }

    }
}
