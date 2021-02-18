using System;
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
        Task<ResponseModel<IEnumerable<EntryModel>>> Search(string searchString);
        Task<ResponseModel<IEnumerable<EntryModel>>> GetByPhoneBookId(int phoneBookId);
    }
}
