using System;
using System.Linq;
using PhoneBook.Logic.Services;
using Xunit;

namespace PhoneBook.Tests.ServiceTests
{
    public class EntryServiceTests
    {
        private readonly IEntryService _entryService;

        public EntryServiceTests(IEntryService entryService)
        {
            _entryService = entryService;
        }


        [Fact]
        public async void ShouldCreateEntry()
        {
            var newEntry = await _entryService.Create(new Models.EntryModel
            {
                Name = "Andrew",
                PhoneBookId = 1,
                PhoneNumber = "0712223333"
            });
            Assert.True(newEntry.EntryId > 1);
        }

        [Fact]
        public async void ShouldSearchEntries()
        {
            var entryCollection = await _entryService.Search("2022");
            Assert.True(entryCollection.DataSet.Count() > 1);
        }
    }
}
