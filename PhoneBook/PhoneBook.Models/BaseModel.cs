using System;
namespace PhoneBook.Models
{
    public class BaseModel
    {
        public string ErrorMessage { get; set; } = "Your request was successful.";
        public bool IsSuccessful { get; set; } = true;
    }
}
