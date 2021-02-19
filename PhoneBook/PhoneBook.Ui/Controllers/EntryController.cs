using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhoneBook.Logic.Services;
using PhoneBook.Models;

namespace PhoneBook.Ui.Controllers
{

    [Route("api/[controller]")]
    public class EntryController : BaseController
    {
        private readonly IEntryService _entryService;
        private ILogger<EntryController> _logger;

        public EntryController(IEntryService entryService, ILogger<EntryController> logger)
        {
            _entryService = entryService;
            _logger = logger;
        }


        [HttpPost]
        public async Task<ResponseModel<EntryOutputModel>> Post([FromBody] EntryInputModel entryInputModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    _logger.LogInformation($"Creating new entry {entryInputModel.Name}");
                    var phonebook = await _entryService.Create(entryInputModel);
                    return phonebook;
                }
                else
                {
                    return new ResponseModel<EntryOutputModel>
                    {
                        IsSuccessful = false,
                        ResponseMessage = "Please make sure you have entered the correct details."
                    };
                }
            }
            catch (Exception exception)
            {
                _logger.LogError($"An exception occurred: {exception.ToString()}");
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
                if (ModelState.IsValid)
                {
                    _logger.LogInformation($"Updating entry: {entryInputModel}");
                    var phonebook = await _entryService.Edit(id, entryInputModel);
                    return phonebook;
                }
                else
                {
                    return new ResponseModel<EntryOutputModel>
                    {
                        IsSuccessful = false,
                        ResponseMessage = "Please make sure you have entered the correct details."
                    };
                }
            }
            catch (Exception exception)
            {
                _logger.LogError($"An exception occurred: {exception.ToString()}");
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
                _logger.LogInformation($"Fetching entries by phonebook id: {phoneBookId}");
                var entries = await _entryService.GetByPhoneBookId(phoneBookId);
                return entries;
            }
            catch (Exception exception)
            {
                _logger.LogError($"An exception occurred: {exception.ToString()}");
                return new ResponseModel<IEnumerable<EntryOutputModel>>
                {

                    ResponseMessage = "An unexpected error occcurred",
                    IsSuccessful = false
                };
            }
        }
    }
}
