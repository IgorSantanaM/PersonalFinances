using AutoMapper;

namespace PersonalFinances.Services.Profiles
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMapping()
        {
            return new MapperConfiguration(ps =>
            {
                ps.AddProfile(new AccountProfile());
            });
        }
    }
}
