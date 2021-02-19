using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhoneBook.Logic.Services;
using PhoneBook.Models;

namespace PhoneBook.Ui.Controllers
{
    [Route("api/[controller]")]
    public class PhoneBookController : BaseController
    {
        private readonly IPhoneBookService _phoneBookService;
        private ILogger<PhoneBookController> _logger;

        public PhoneBookController(IPhoneBookService phoneBookService, ILogger<PhoneBookController> logger)
        {
            _phoneBookService = phoneBookService;
            _logger = logger;
        }
        [HttpGet]
        public ResponseModel<IEnumerable<PhoneBookOutputModel>> GetAll()
        {
            try
            {
                _logger.LogInformation("Fetching phonebook list.");
                var phonebooks = _phoneBookService.GetPhonebooks();
                return phonebooks;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"An exception occurred: {exception.ToString()}");
                return new ResponseModel<IEnumerable<PhoneBookOutputModel>>
                {
                    ResponseMessage = "An unexpected error occcurred",
                    IsSuccessful = false
                };
            }
        }

        [HttpPost]
        public async Task<ResponseModel<PhoneBookOutputModel>> Post([FromBody]PhoneBookInputModel phoneBookModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.LogInformation($"Creating new phonebook: {phoneBookModel.Name}");
                    var phonebook = await _phoneBookService.Create(phoneBookModel);
                    return phonebook;
                }
                else
                {
                    return new ResponseModel<PhoneBookOutputModel>
                    {
                        IsSuccessful = false,
                        ResponseMessage = "Please make sure you have entered the correct details."
                    };
                }
            }
            catch (Exception exception)
            {
                _logger.LogError($"An exception occurred: {exception.ToString()}");
                return new ResponseModel<PhoneBookOutputModel>
                {
                    ResponseMessage = "An unexpected error occcurred",
                    IsSuccessful = false
                };
            }
        }
        [HttpPut("{id}")]
        public async Task<ResponseModel<PhoneBookOutputModel>> Edit(int id, [FromBody] PhoneBookInputModel phoneBookModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.LogInformation($"Updating phonebook: {phoneBookModel.Name}");
                    var phonebook = await _phoneBookService.Edit(id, phoneBookModel);
                    return phonebook;
                }
                else
                {
                    return new ResponseModel<PhoneBookOutputModel>
                    {
                        IsSuccessful = false,
                        ResponseMessage = "Please make sure you have entered the correct details."
                    };
                }
            }
            catch (Exception exception)
            {
                _logger.LogError($"An exception occurred: {exception.ToString()}");
                return new ResponseModel<PhoneBookOutputModel>
                {
                    ResponseMessage = "An unexpected error occcurred",
                    IsSuccessful = false
                };
            }
        }
        [HttpGet("{id}")]
        public ResponseModel<PhoneBookOutputModel> GetById(int id)
        {
            try
            {
                _logger.LogInformation($"Fetching phonebook wiht id: {id}");
                var phonebook =  _phoneBookService.GetById(id);
                return phonebook;
            }
            catch (Exception exception)
            {
                _logger.LogError($"An exception occurred: {exception.ToString()}");
                return new ResponseModel<PhoneBookOutputModel>
                {
                    ResponseMessage = "An unexpected error occcurred",
                    IsSuccessful = false
                };
            }
        }

    }


}
