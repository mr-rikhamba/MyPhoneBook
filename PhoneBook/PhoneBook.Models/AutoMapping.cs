using System;
using AutoMapper;
using PhoneBook.Core;

namespace PhoneBook.Models
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {

         //   CreateMap<Entry, EntryModel>();
            CreateMap<Entry, EntryOutputModel>().ReverseMap();
      //      CreateMap<Core.PhoneBook, PhoneBookOutputModel>();
            CreateMap<Core.PhoneBook, PhoneBookOutputModel>().ReverseMap();
       //     CreateMap<Core.PhoneBook, PhoneBookInputModel>();
            CreateMap<Core.PhoneBook, PhoneBookInputModel>().ReverseMap();


        }
    }
}
