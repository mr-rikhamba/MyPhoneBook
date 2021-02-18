using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Logic.Services;
using PhoneBook.Models;

namespace PhoneBook.Ui.Controllers
{

    [Route("api/[controller]")]
    public class EntryController : BaseController
    {
        private readonly IEntryService _entryService;

        public EntryController(IEntryService entryService)
        {
            _entryService = entryService;
        }


        [HttpPost]
        public async Task<ResponseModel<EntryOutputModel>> Post([FromBody] EntryInputModel entryInputModel)
        {
            try
            {
                var phonebook = await _entryService.Create(entryInputModel);
                return phonebook;
            }
            catch (Exception exception)
            {
                LogException(exception);
                return new ResponseModel<EntryOutputModel>
                {
                    ResponseMessage = "An unexpected error occcurred",
                    IsSuccessful = false
                };
            }
        }
        [HttpPut("{id}")]
        public async Task<ResponseModel<EntryOutputModel>> Edit(int id, [FromBody] EntryInputModel entryInputModel)
        {
            try
            {
                var phonebook = await _entryService.Edit(id, entryInputModel);
                return phonebook;
            }
            catch (Exception exception)
            {
                LogException(exception);
                return new ResponseModel<EntryOutputModel>
                {
                    ResponseMessage = "An unexpected error occcurred",
                    IsSuccessful = false
                };
            }
        }
        [HttpGet("{phoneBookId}")]
        public async Task<ResponseModel<IEnumerable<EntryOutputModel>>> GetByPhoneBookId(int phoneBookId)
        {
            try
            {
                var entries = await _entryService.GetByPhoneBookId(phoneBookId);
                return entries;
            }
            catch (Exception exception)
            {
                LogException(exception);
                return new ResponseModel<IEnumerable<EntryOutputModel>>
                {

                    ResponseMessage = "An unexpected error occcurred",
                    IsSuccessful = false
                };
            }
        }
    }
}
