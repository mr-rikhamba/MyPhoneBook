using System;
using AutoMapper;
using PhoneBook.Core;

namespace PhoneBook.Models
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {

            CreateMap<Entry, EntryModel>();
            CreateMap<Entry, EntryModel>().ReverseMap();
            CreateMap<Core.PhoneBook, PhoneBookModel>();
            CreateMap<Core.PhoneBook, PhoneBookModel>().ReverseMap();


        }
    }
}
