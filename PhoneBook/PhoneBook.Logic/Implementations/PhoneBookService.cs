using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PhoneBook.Core;
using PhoneBook.Logic.Services;
using PhoneBook.Models;

namespace PhoneBook.Logic.Implementations
{
    public class PhoneBookService : IPhoneBookService
    {
        private readonly IMapper _mapper;

        public PhoneBookService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<PhoneBookModel> Create(PhoneBookModel phoneBookModel)
        {
            try
            {
                using (var ctx = new PhoneBookContext())
                {
                    var entity = _mapper.Map<PhoneBookModel, Core.PhoneBook>(phoneBookModel);
                    ctx.PhoneBooks.Add(entity);
                    await ctx.SaveChangesAsync();
                    phoneBookModel.PhoneBookId = entity.PhoneBookId;
                    return phoneBookModel;
                }
            }
            catch (Exception ex)
            {
                return new PhoneBookModel { ErrorMessage = Constants.UnexpectedError, IsSuccessful = false };
            }
        }

        public async Task<PhoneBookModel> Edit(PhoneBookModel phoneBookModel)
        {
            try
            {
                using (var ctx = new PhoneBookContext())
                {
                    var existingPhoneBook = ctx.PhoneBooks.FirstOrDefault(x => x.PhoneBookId == phoneBookModel.PhoneBookId);
                    if (existingPhoneBook.Name != phoneBookModel.Name)
                    {
                        existingPhoneBook.Name = phoneBookModel.Name;
                        await ctx.SaveChangesAsync();
                    }
                    return _mapper.Map<Core.PhoneBook, PhoneBookModel>(existingPhoneBook);
                }
            }
            catch (Exception ex)
            {
                return new PhoneBookModel { ErrorMessage = Constants.UnexpectedError, IsSuccessful = false };
            }
        }

        public PhoneBookModel GetById(int id)
        {
            try
            {
                using (var ctx = new PhoneBookContext())
                {
                    var phoneBookModel = ctx.PhoneBooks.FirstOrDefault(x => x.PhoneBookId == id);
                    if (phoneBookModel== null)
                    {
                        return new PhoneBookModel { ErrorMessage = Constants.IdNotFound, IsSuccessful = false };
                    }
                    return _mapper.Map<Core.PhoneBook, PhoneBookModel>(phoneBookModel);
                }
            }
            catch (Exception ex)
            {
                return new PhoneBookModel { ErrorMessage = Constants.UnexpectedError, IsSuccessful = false };
            }
        }
    }
}
