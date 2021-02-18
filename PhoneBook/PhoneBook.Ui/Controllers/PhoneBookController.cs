using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Logic.Services;
using PhoneBook.Models;

namespace PhoneBook.Ui.Controllers
{
    [Route("api/[controller]")]
    public class PhoneBookController : BaseController
    {
        private readonly IPhoneBookService _phoneBookService;

        public PhoneBookController(IPhoneBookService phoneBookService)
        {
            _phoneBookService = phoneBookService;
        }
        [HttpGet]
        public ResponseModel<IEnumerable<PhoneBookOutputModel>> GetAll()
        {
            try
            {
                var phonebooks = _phoneBookService.GetPhonebooks();
                return phonebooks;
            }
            catch (Exception exception)
            {
                LogException(exception);
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
                var phonebook = await _phoneBookService.Create(phoneBookModel);
                return phonebook;
            }
            catch (Exception exception)
            {
                LogException(exception);
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
                var phonebook = await _phoneBookService.Edit(id, phoneBookModel);
                return phonebook;
            }
            catch (Exception exception)
            {
                LogException(exception);
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
                var phonebook =  _phoneBookService.GetById(id);
                return phonebook;
            }
            catch (Exception exception)
            {
                LogException(exception);
                return new ResponseModel<PhoneBookOutputModel>
                {
                    ResponseMessage = "An unexpected error occcurred",
                    IsSuccessful = false
                };
            }
        }
    }


}
