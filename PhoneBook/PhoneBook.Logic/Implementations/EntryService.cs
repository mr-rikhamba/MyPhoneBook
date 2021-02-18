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

        public async Task<EntryModel> Create(EntryModel entryModel)
        {
            try
            {
                using (var ctx = new PhoneBookContext())
                {
                    var entity = _mapper.Map<EntryModel, Core.Entry>(entryModel);
                    ctx.Entries.Add(entity);
                    await ctx.SaveChangesAsync();
                    entryModel.EntryId = entity.PhoneBookId;
                    return entryModel;
                }
            }
            catch (Exception ex)
            {
                return new EntryModel { ResponseMessage = Constants.UnexpectedError, IsSuccessful = false };
            }
        }

        public async Task<EntryModel> Edit(EntryModel entryModel)
        {
            try
            {
                using (var ctx = new PhoneBookContext())
                {
                    var existinEntry = ctx.Entries.FirstOrDefault(x => x.EntryId == entryModel.EntryId);
                    if (existinEntry.Name != existinEntry.Name || existinEntry.PhoneNumber != entryModel.PhoneNumber || existinEntry.PhoneBookId != entryModel.PhoneBookId)
                    {
                        existinEntry.Name = entryModel.Name;
                        existinEntry.PhoneNumber = entryModel.PhoneNumber;
                        existinEntry.PhoneBookId = entryModel.PhoneBookId;
                        await ctx.SaveChangesAsync();
                    }
                    return _mapper.Map<Core.Entry, EntryModel>(existinEntry);
                }
            }
            catch (Exception ex)
            {
                return new EntryModel { ResponseMessage = Constants.UnexpectedError, IsSuccessful = false };
            }
        }

        public async Task<ResponseModel<IEnumerable<EntryModel>>> GetByPhoneBookId(int phoneBookId)
        {
            try
            {
                using (var ctx = new PhoneBookContext())
                {
                    var entries = ctx.Entries.Where(x => x.PhoneBookId == phoneBookId);
                    if (entries.Count() == 0)
                    {
                        return new ResponseModel<IEnumerable<EntryModel>> { ResponseMessage = Constants.RecordsNotFound, IsSuccessful = false };
                    }

                    return new ResponseModel<IEnumerable<EntryModel>>
                    {
                        DataSet = entries.Select(_mapper.Map<EntryModel>).ToList()
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel<IEnumerable<EntryModel>> { ResponseMessage = Constants.UnexpectedError, IsSuccessful = false };
            }
        }

        public async Task<ResponseModel<IEnumerable<EntryModel>>> Search(string searchString)
        {
            try
            {
                using (var ctx = new PhoneBookContext())
                {
                    var entries = ctx.Entries.Where(x => x.Name.ToLower().Contains(searchString) || x.PhoneNumber.ToLower().Contains(searchString));
                    if (entries.Count() == 0)
                    {
                        return new ResponseModel<IEnumerable<EntryModel>> { ResponseMessage = Constants.RecordsNotFound, IsSuccessful = false };
                    }

                    return new ResponseModel<IEnumerable<EntryModel>>
                    {
                        DataSet = entries.Select(_mapper.Map<EntryModel>).ToList()
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel<IEnumerable<EntryModel>> { ResponseMessage = Constants.UnexpectedError, IsSuccessful = false };
            }
        }
    }
}
