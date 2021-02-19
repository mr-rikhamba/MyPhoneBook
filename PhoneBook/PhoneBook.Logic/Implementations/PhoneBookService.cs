using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public async Task<ResponseModel<PhoneBookOutputModel>> Create(PhoneBookInputModel phoneBookModel)
        {
            try
            {
                using (var ctx = new PhoneBookContext())
                {
                    var entity = _mapper.Map<PhoneBookInputModel, Core.PhoneBook>(phoneBookModel);
                    ctx.PhoneBooks.Add(entity);
                    await ctx.SaveChangesAsync();
                    return new ResponseModel<PhoneBookOutputModel> { DataSet = _mapper.Map<Core.PhoneBook, PhoneBookOutputModel>(entity) };
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel<PhoneBookOutputModel> { ResponseMessage = Constants.UnexpectedError, IsSuccessful = false };
            }
        }

        public async Task<ResponseModel<PhoneBookOutputModel>> Edit(int id, PhoneBookInputModel phoneBookModel)
        {
            try
            {
                using (var ctx = new PhoneBookContext())
                {
                    var existingPhoneBook = ctx.PhoneBooks.FirstOrDefault(x => x.PhoneBookId == id);
                    if (existingPhoneBook.Name != phoneBookModel.Name)
                    {
                        existingPhoneBook.Name = phoneBookModel.Name;
                        await ctx.SaveChangesAsync();
                    }
                    return new ResponseModel<PhoneBookOutputModel> { DataSet = _mapper.Map<Core.PhoneBook, PhoneBookOutputModel>(existingPhoneBook) };
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel<PhoneBookOutputModel> { ResponseMessage = Constants.UnexpectedError, IsSuccessful = false };
            }
        }

        public ResponseModel<PhoneBookOutputModel> GetById(int id)
        {
            try
            {
                using (var ctx = new PhoneBookContext())
                {
                    var phoneBookModel = ctx.PhoneBooks.Include(c=>c.Entries).FirstOrDefault(x => x.PhoneBookId == id);
                    if (phoneBookModel == null)
                    {
                        return new ResponseModel<PhoneBookOutputModel> { ResponseMessage = Constants.UnexpectedError, IsSuccessful = false };
                    }
                    return new ResponseModel<PhoneBookOutputModel> { DataSet = _mapper.Map<Core.PhoneBook, PhoneBookOutputModel>(phoneBookModel) };
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel<PhoneBookOutputModel> { ResponseMessage = Constants.UnexpectedError, IsSuccessful = false };
            }
        }

        public ResponseModel<IEnumerable<PhoneBookOutputModel>> GetPhonebooks()
        {
            using (var ctx = new PhoneBookContext())
            {
                var phoneBooks = ctx.PhoneBooks.Include(c=> c.Entries).ToList();
                return new ResponseModel<IEnumerable<PhoneBookOutputModel>> { DataSet = phoneBooks.Select(_mapper.Map<PhoneBookOutputModel>).OrderBy(e=>e.Name).ToList() };
            }
        }
    }
}
