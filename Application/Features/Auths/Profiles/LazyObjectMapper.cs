using Application.Features.Categories.Profiles;
using AutoMapper;

namespace Application.Features.Auths.Profiles
{
    public static class LazyObjectMapper
    {
        private static readonly Lazy<IMapper> lazy = new(() =>
        {
            var config = new MapperConfiguration(configuration => { configuration.AddProfile<AuthProfile>(); });
            return config.CreateMapper();
        });
        public static IMapper Mapper => lazy.Value;

    }
}
