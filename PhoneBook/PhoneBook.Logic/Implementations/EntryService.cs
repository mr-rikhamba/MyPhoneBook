using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PhoneBook.Core;
using PhoneBook.Logic.Services;
using PhoneBook.Models;

namespace PhoneBook.Logic.Implementations
{
    public class EntryService:IEntryService
    {
        private IMapper _mapper;

        public EntryService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ResponseModel<EntryOutputModel>> Create(EntryInputModel entryModel)
        {
            try
            {
                using (var ctx = new PhoneBookContext())
                {
                    var entity = _mapper.Map<EntryInputModel, Core.Entry>(entryModel);
                    ctx.Entries.Add(entity);
                    await ctx.SaveChangesAsync();
                    return new ResponseModel<EntryOutputModel> { DataSet = _mapper.Map<Core.Entry, EntryOutputModel>(entity) };
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel<EntryOutputModel> { ResponseMessage = Constants.UnexpectedError, IsSuccessful = false };
            }
        }

        public async Task<ResponseModel<EntryOutputModel>> Edit(int entryId, EntryInputModel entryModel)
        {
            try
            {
                using (var ctx = new PhoneBookContext())
                {
                    var existinEntry = ctx.Entries.FirstOrDefault(x => x.EntryId == entryId);
                    if (existinEntry.Name != existinEntry.Name || existinEntry.PhoneNumber != entryModel.PhoneNumber || existinEntry.PhoneBookId != entryModel.PhoneBookId)
                    {
                        existinEntry.Name = entryModel.Name;
                        existinEntry.PhoneNumber = entryModel.PhoneNumber;
                        existinEntry.PhoneBookId = entryModel.PhoneBookId;
                        await ctx.SaveChangesAsync();
                    }
                    return new ResponseModel<EntryOutputModel> { DataSet = _mapper.Map<Core.Entry, EntryOutputModel>(existinEntry) };
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel<EntryOutputModel> { ResponseMessage = Constants.UnexpectedError, IsSuccessful = false };
            }
        }

        public async Task<ResponseModel<IEnumerable<EntryOutputModel>>> GetByPhoneBookId(int phoneBookId)
        {
            try
            {
                using (var ctx = new PhoneBookContext())
                {
                    var entries = ctx.Entries.Where(x => x.PhoneBookId == phoneBookId);
                    if (entries.Count() == 0)
                    {
                        return new ResponseModel<IEnumerable<EntryOutputModel>> { ResponseMessage = Constants.RecordsNotFound, IsSuccessful = false };
                    }

                    return new ResponseModel<IEnumerable<EntryOutputModel>>
                    {
                        DataSet = entries.Select(_mapper.Map<EntryOutputModel>).ToList()
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel<IEnumerable<EntryOutputModel>> { ResponseMessage = Constants.UnexpectedError, IsSuccessful = false };
            }
        }

        public async Task<ResponseModel<IEnumerable<EntryOutputModel>>> Search(string searchString)
        {
            try
            {
                using (var ctx = new PhoneBookContext())
                {
                    var entries = ctx.Entries.Where(x => x.Name.ToLower().Contains(searchString) || x.PhoneNumber.ToLower().Contains(searchString));
                    if (entries.Count() == 0)
                    {
                        return new ResponseModel<IEnumerable<EntryOutputModel>> { ResponseMessage = Constants.RecordsNotFound, IsSuccessful = false };
                    }

                    return new ResponseModel<IEnumerable<EntryOutputModel>>
                    {
                        DataSet = entries.Select(_mapper.Map<EntryOutputModel>).ToList()
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel<IEnumerable<EntryOutputModel>> { ResponseMessage = Constants.UnexpectedError, IsSuccessful = false };
            }
        }
    }
}
