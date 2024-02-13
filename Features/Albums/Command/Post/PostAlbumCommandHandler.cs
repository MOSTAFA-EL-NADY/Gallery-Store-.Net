using AutoMapper;
using Gallery.Dto;
using Gallery.Helper;
using Gallery.Interface;
using Gallery.Models;
using Gallery.Services;
using MediatR;

namespace Gallery.Features.Albums.Command.Post
{
    public class PostAlbumCommandHandler : IRequestHandler<PostAlbumCommand, ResponseDto>
    {
        private readonly IMapper _mapper;
        private readonly IGRepository<Album> _albumRepository;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly int loggedInUserId;
        private readonly ResponseHelper _response;

        public PostAlbumCommandHandler(IMapper mapper,
                                       IGRepository<Album> albumRepository,
                                       IWebHostEnvironment hostEnvironment,
                                       IHttpContextAccessor contextAccessor,
                                       ResponseHelper response)
        {
            _mapper = mapper;
            _albumRepository = albumRepository;
            _hostEnvironment = hostEnvironment;
            _contextAccessor = contextAccessor;
            loggedInUserId = LoggedInUserProvider.GetLoggedInUserId(contextAccessor);
            _response = response;
        }

        public async Task<ResponseDto> Handle(PostAlbumCommand request, CancellationToken cancellationToken)
        {
            var newAlbum = _mapper.Map<Album>(request);

            if (request.MainImage is not null)
                newAlbum.MainImage = await UploadHelper.UploadImage(request.MainImage, _hostEnvironment, loggedInUserId.ToString());

            await _albumRepository.AddAsync(newAlbum);
            _albumRepository.Save();

            return _response.SavedSuccessfully(newAlbum, "Album Created Successfully");
        }
    }
}
