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

        
        [Theory]
        [InlineData("Test Entry", 1, "0119092000")]
        public async void ShouldCreateEntry(string name, int phonebookId, string phoneNumber)
        {
            var newEntry = await _entryService.Create(new Models.EntryOutputModel
            {
                Name = name,
                PhoneBookId = phonebookId,
                PhoneNumber = phoneNumber
            });
            Assert.True(newEntry.DataSet.EntryId > 1);
        }

        [Fact]
        public async void ShouldSearchEntries()
        {
            var entryCollection = await _entryService.Search("entry");
            Assert.True(entryCollection.DataSet.Count() > 0);
        }
        [Theory]
        [InlineData(37, 2)]
        public async void ShouldGetEntriesByPhonebook(int phonebookId, int expected)
        {
            var entryCollection = await _entryService.GetByPhoneBookId(phonebookId);
            Assert.True(entryCollection.DataSet.Count() == expected);
        }
    }
}
