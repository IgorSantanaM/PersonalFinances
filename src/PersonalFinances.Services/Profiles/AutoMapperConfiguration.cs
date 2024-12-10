using AutoMapper;
using PersonalFinances.Services.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Services.Profiles
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMapping()
        {
            return new MapperConfiguration(ps =>
            {
                ps.AddProfile(new AccountsProfile());
            });
        }
    }
}
