using System;
using System.Threading.Tasks;
using PhoneBook.Models;

namespace PhoneBook.Logic.Services
{
    public interface IPhoneBookService
    {
        Task<PhoneBookModel> Create(PhoneBookModel phoneBookModel);
        Task<PhoneBookModel> Edit(PhoneBookModel phoneBookModel);
        PhoneBookModel GetById(int id);
    }
}
