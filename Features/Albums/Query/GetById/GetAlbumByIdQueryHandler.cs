using AutoMapper;
using Gallery.Dto;
using Gallery.Helper;
using Gallery.Interface;
using Gallery.Models;
using Gallery.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gallery.Features.Albums.Query.GetById
{
    public class GetAlbumByIdQueryHandler : IRequestHandler<GetAlbumByIdQuery, ResponseDto>
    {
        private readonly IGRepository<Album> _albumRepp;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly int loggedinUserId;
        private readonly IMapper _mapper;
        private readonly ResponseHelper _response;
        public GetAlbumByIdQueryHandler(IGRepository<Album> albumRepp,
                                       IHttpContextAccessor contextAccessor,
                                       IMapper mapper,
                                       ResponseHelper response)
        {
            _albumRepp = albumRepp;
            _contextAccessor = contextAccessor;
            loggedinUserId = LoggedInUserProvider.GetLoggedInUserId(_contextAccessor);
            _mapper = mapper;
            _response = response;
        }
        public async Task<ResponseDto> Handle(GetAlbumByIdQuery request, CancellationToken cancellationToken)
        {
            var album = _albumRepp.GetAll(a => a.Id == request.Id && a.CreatedBy == loggedinUserId)
                                        .Include(a => a.Images)
                                        .OrderByDescending(a => a.CreatedOn)
                                        .FirstOrDefault();
            if (album == null)
                return _response.NotFound("the Album Not Found");

            var albumResponse = _mapper.Map<AlbumDto>(album);

            return _response.RetrievedSuccessfully(albumResponse, "Album Retrieved Successfully");
        }
    }
}
