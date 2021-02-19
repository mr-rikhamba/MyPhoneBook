using System;
using PhoneBook.Logic.Services;
using Xunit;

namespace PhoneBook.Tests.ServiceTests
{
    public class PhoneBookServiceTests
    {
        private readonly IPhoneBookService _phoneBookService;

        public PhoneBookServiceTests(IPhoneBookService phoneBookService)
        {
            _phoneBookService = phoneBookService;
        }

        [Fact]
        public async void ShouldCreatePhoneBook()
        {
            var newPhoneBook = await _phoneBookService.Create(new Models.PhoneBookInputModel { Name = "PhoneBook 3" });
            Assert.True(newPhoneBook.IsSuccessful);
        }

        [Fact]
        public void ShouldGetAPhoneBook()
        {
            var newPhoneBook = _phoneBookService.GetById(1);
            Assert.Equal(1, newPhoneBook.DataSet.PhoneBookId);
            Assert.True(newPhoneBook.DataSet.EntriesCount > 0);
        }

        [Theory]
        [InlineData(1,"2021 Phonebook")]
        [InlineData(2, "2022 Phonebook")]
        public async  void ShouldEditPhoneBook(int phoneBookId, string newPhoneName)
        {
            var phoneBookName = newPhoneName;
            var existingPhoneBook = _phoneBookService.GetById(phoneBookId);
            var updatedPhonebook = await _phoneBookService.Edit(existingPhoneBook.DataSet.PhoneBookId, new Models.PhoneBookInputModel {
            Name = phoneBookName
            });
            Assert.Equal(phoneBookName, updatedPhonebook.DataSet.Name);
        }
    }
}
