using System;
namespace PhoneBook.Models
{
    public class BaseModel
    {
        public string ResponseMessage { get; set; } = "Your request was successful.";
        public bool IsSuccessful { get; set; } = true;
    }
}
