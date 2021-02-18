using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using PhoneBook.Logic.Services;
using PhoneBook.Models;

namespace PhoneBook.Ui.Controllers
{
    public class PhoneBookController: BaseController
    {
        private readonly IPhoneBookService _phoneBookService;

        public PhoneBookController(IPhoneBookService phoneBookService)
        {
            _phoneBookService = phoneBookService;
        }
        public ResponseModel<IEnumerable<PhoneBookModel>> GetAll()
        {
            try
            {
                var phonebooks = _phoneBookService.GetPhonebooks();
                return phonebooks;
            }
            catch (Exception exception)
            {
                LogException(exception);
                return new ResponseModel<IEnumerable<PhoneBookModel>>
                {
                    ResponseMessage = "An unexpected error occcurred",
                    IsSuccessful = false
                };
            }
        }

        [HttpPost]
        public async Task<ResponseModel<PhoneBookModel>> Post([FromBody] PhoneBookModel phoneBookModel)
        {
            try
            {
                var phonebook = await _phoneBookService.Create(phoneBookModel);
                return new ResponseModel<PhoneBookModel> { DataSet = phonebook};
            }
            catch (Exception exception)
            {
                LogException(exception);
                return new ResponseModel<PhoneBookModel>
                {
                    ResponseMessage = "An unexpected error occcurred",
                    IsSuccessful = false
                };
            }
        }
        public async Task<ResponseModel<PhoneBookModel>> Edit([FromBody] PhoneBookModel phoneBookModel)
        {
            try
            {
                var phonebook = await _phoneBookService.Edit(phoneBookModel);
                return new ResponseModel<PhoneBookModel> { DataSet = phonebook };
            }
            catch (Exception exception)
            {
                LogException(exception);
                return new ResponseModel<PhoneBookModel>
                {
                    ResponseMessage = "An unexpected error occcurred",
                    IsSuccessful = false
                };
            }
        }
        public ResponseModel<PhoneBookModel> GetById(int id)
        {
            try
            {
                var phonebook =  _phoneBookService.GetById(id);
                return new ResponseModel<PhoneBookModel> { DataSet = phonebook };
            }
            catch (Exception exception)
            {
                LogException(exception);
                return new ResponseModel<PhoneBookModel>
                {
                    ResponseMessage = "An unexpected error occcurred",
                    IsSuccessful = false
                };
            }
        }
    }


}
