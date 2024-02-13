using Gallery.Dto;
using Gallery.Helper;
using Gallery.Interface;
using Gallery.Models;
using Gallery.Services;
using MediatR;

namespace Gallery.Features.Albums.Query.GetAll
{
    public class GetAllAlbumQueryHandler : IRequestHandler<GetAllAlbumQuery, ResponseDto>
    {
        private readonly IGRepository<Album> _albumRepo;
        private readonly int loggedInUserId;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ResponseHelper _response;

        public GetAllAlbumQueryHandler(IGRepository<Album> albumRepo,
                                       IHttpContextAccessor contextAccessor,
                                       ResponseHelper response)
        {
            _albumRepo = albumRepo;
            _contextAccessor = contextAccessor;
            loggedInUserId = LoggedInUserProvider.GetLoggedInUserId(_contextAccessor);
            _response = response;
        }

        public async Task<ResponseDto> Handle(GetAllAlbumQuery request, CancellationToken cancellationToken)
        {
            var allAlbums = _albumRepo.GetAll(a => a.CreatedBy == loggedInUserId)
                 .OrderByDescending(a => a.CreatedOn)
                 .Select(a => new GetAllAlbumDto(a.Id, a.Title, a.Description, a.CreatedOn, a.MainImage))
                 .ToList();

            return _response.RetrievedSuccessfully(allAlbums, "Albums Retrived Successfully");
        }
    }
}
