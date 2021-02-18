using System;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Logic.Services;

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
    }
}
