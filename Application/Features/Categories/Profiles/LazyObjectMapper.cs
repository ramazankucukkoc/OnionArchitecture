using AutoMapper;

namespace Application.Features.Categories.Profiles
{
    public static class LazyObjectMapper
    {
        private static readonly Lazy<IMapper> lazy = new(() =>
        {
            var config = new MapperConfiguration(configuration => { configuration.AddProfile<CategoryProfile>(); });
            return config.CreateMapper();
        });
        public static IMapper Mapper => lazy.Value;

    }
}
