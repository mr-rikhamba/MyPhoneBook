using System;
using System.Collections.Generic;

namespace PhoneBook.Models
{
    public class ResponseModel<T> : BaseModel
    {
        public T DataSet { get; set; }

    }
}
