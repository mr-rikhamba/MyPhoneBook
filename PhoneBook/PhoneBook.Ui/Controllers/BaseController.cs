using System;
using Microsoft.AspNetCore.Mvc;

namespace PhoneBook.Ui.Controllers
{
    public class BaseController: ControllerBase
    {
        [NonAction]
        public void LogException(Exception ex)
        {

            //TODO: Log Exceptions
        }
        public BaseController()
        {
        }
    }
}
