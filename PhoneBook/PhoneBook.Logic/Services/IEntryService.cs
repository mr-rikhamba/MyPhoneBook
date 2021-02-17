﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneBook.Models;

namespace PhoneBook.Logic.Services
{
    public interface IEntryService
    {
        Task<EntryModel> Create(EntryModel entryModel);
        Task<EntryModel> Edit(EntryModel entryModel);
        Task<EntryCollectionModel> Search(string searchString);
    }
}
