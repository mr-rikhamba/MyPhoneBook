using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneBook.Models;

namespace PhoneBook.Logic.Services
{
    public interface IPhoneBookService
    {
        Task<ResponseModel<PhoneBookOutputModel>> Create(PhoneBookInputModel phoneBookModel);
        Task<ResponseModel<PhoneBookOutputModel>> Edit(int id, PhoneBookInputModel phoneBookModel);
        ResponseModel<PhoneBookOutputModel> GetById(int id);
        ResponseModel<IEnumerable<PhoneBookOutputModel>> GetPhonebooks();
    }
}
