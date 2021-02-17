using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Core;
using PhoneBook.Logic.Implementations;
using PhoneBook.Logic.Services;
using PhoneBook.Models;

namespace PhoneBook.Tests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(c => c.AddProfile<AutoMapping>(), typeof(Startup));
            services.AddDbContext<PhoneBookContext>(options => options.UseSqlServer("Data Source=156.38.224.15;Initial Catalog=atlaspro_phonebook;Persist Security Info=True;User ID=atlaspro_tempAssessmentUser;Password=G2m0l7z*"));
            services.AddSingleton<IPhoneBookService, PhoneBookService>();
            services.AddSingleton<IEntryService, EntryService>();
        }
    }
}
