using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneBook.Models;

namespace PhoneBook.Logic.Services
{
    public interface IEntryService
    {
        Task<ResponseModel<EntryOutputModel>> Create(EntryInputModel entryModel);
        Task<ResponseModel<EntryOutputModel>> Edit(int entryId, EntryInputModel entryModel);
        Task<ResponseModel<IEnumerable<EntryOutputModel>>> Search(string searchString);
        Task<ResponseModel<IEnumerable<EntryOutputModel>>> GetByPhoneBookId(int phoneBookId);
    }
}
