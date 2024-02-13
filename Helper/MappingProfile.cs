namespace Gallery.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PostAlbumCommand, Album>();

            CreateMap<RegisterCommand, User>();

            CreateMap<Album, AlbumDto>();

            CreateMap<Image, ImageDto>()
                .ForMember(s => s.SizeInMB, opt => opt.MapFrom(d => Math.Round((double)d.Size / (1024 * 1024), 2)));
            CreateMap<User, UserDto>();
        }
    }
}
