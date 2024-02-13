using Gallery.Dto;
using Gallery.Helper;
using Gallery.Interface;
using Gallery.Models;
using Gallery.Services;
using MediatR;

namespace Gallery.Features.Albums.Command.Put
{
    public class PutAlbumCommandHandler : IRequestHandler<PutAlbumCommand, ResponseDto>
    {
        private readonly IGRepository<Album> _albumRepository;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly int loggedInUserId;
        private readonly ResponseHelper _response;

        public PutAlbumCommandHandler(IGRepository<Album> albumRepository, IWebHostEnvironment hostEnvironment, IHttpContextAccessor contextAccessor, ResponseHelper response)
        {
            _albumRepository = albumRepository;
            _hostEnvironment = hostEnvironment;
            _contextAccessor = contextAccessor;
            _response = response;
            loggedInUserId = LoggedInUserProvider.GetLoggedInUserId(contextAccessor);
        }

        public async Task<ResponseDto> Handle(PutAlbumCommand request, CancellationToken cancellationToken)
        {
            var album = _albumRepository.GetFirst(a => a.Id == request.AlbumId);
            if (album == null)
                return _response.NotFound("this album not found");

            album.Title = request.PutAlbumDto.Title ?? "";
            album.Description = request.PutAlbumDto.Description;
            if (request.PutAlbumDto.MainImage is not null)
            {
                album.MainImage = await UploadHelper.UploadImage(request.PutAlbumDto.MainImage, _hostEnvironment, loggedInUserId.ToString());
            }
            _albumRepository.Update(album);
            _albumRepository.Save();
            return _response.SavedSuccessfully("album updated Successfully");
        }
    }
}
