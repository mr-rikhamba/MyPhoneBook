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
            var newPhoneBook = await _phoneBookService.Create(new Models.PhoneBookModel { Name = "PhoneBook 3" });
            Assert.True(newPhoneBook.IsSuccessful);
        }

        [Fact]
        public void ShouldGetAPhoneBook()
        {
            var newPhoneBook = _phoneBookService.GetById(1);
            Assert.Equal(1, newPhoneBook.PhoneBookId);
        }

        [Theory]
        [InlineData("2021 Phonebook")]
        [InlineData("2022 Phonebook")]
        [InlineData("2023 Phonebook")]
        [InlineData("")]
        public async  void ShouldEditPhoneBook(string newPhoneName)
        {
            var phoneBookName = newPhoneName;
            var existingPhoneBook = _phoneBookService.GetById(1);
            existingPhoneBook.Name = phoneBookName;
            var updatedPhonebook = await _phoneBookService.Edit(existingPhoneBook);
            Assert.Equal(phoneBookName, updatedPhonebook.Name);
        }
    }
}
