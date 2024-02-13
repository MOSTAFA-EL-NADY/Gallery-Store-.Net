using Gallery.Dto;
using Gallery.Helper;
using Gallery.Interface;
using Gallery.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gallery.Features.Albums.Command.Delete
{
    public class DeleteAlbumCommandHandler : IRequestHandler<DeleteAlbumCommand, ResponseDto>
    {
        private readonly IGRepository<Album> _albumRepo;
        private readonly ResponseHelper _response;
        public DeleteAlbumCommandHandler(IGRepository<Album> albumRepo, ResponseHelper response)
        {
            _albumRepo = albumRepo;
            _response = response;
        }

        public async Task<ResponseDto> Handle(DeleteAlbumCommand request, CancellationToken cancellationToken)
        {
            var album = _albumRepo.GetAll(a => a.Id == request.AlbumId)
                .Include(a => a.Images)
                .FirstOrDefault();
            if (album == null)
                return _response.NotFound("Album Not Found");

            if (album.MainImage is not null)
                File.Delete(album.MainImage);

            if (album.Images is not null)
                foreach (var image in album.Images)
                {
                    File.Delete(image.Url);
                }

            _albumRepo.Remove(album);
            _albumRepo.Save();

            return _response.SavedSuccessfully("Album Deleted Successfully");
        }
    }
}
