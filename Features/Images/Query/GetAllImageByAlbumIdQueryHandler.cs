using AutoMapper;
using Gallery.Dto;
using Gallery.Features.Albums.Query.GetById;
using Gallery.Helper;
using Gallery.Interface;
using Gallery.Models;
using MediatR;

namespace Gallery.Features.Images.Query
{
    public class GetAllImageByAlbumIdQueryHandler : IRequestHandler<GetAllImageByAlbumIdQuery, ImageResponseDto>
    {
        private readonly IGRepository<Image> _imageRepo;
        private readonly IMapper _mapper;
        private readonly ResponseHelper _response;

        public GetAllImageByAlbumIdQueryHandler(IGRepository<Image> albumRepo, IMapper mapper, ResponseHelper response)
        {
            _imageRepo = albumRepo;
            _mapper = mapper;
            _response = response;
        }

        public async Task<ImageResponseDto> Handle(GetAllImageByAlbumIdQuery request, CancellationToken cancellationToken)
        {
            var allImages = _imageRepo.GetAll(i => i.AlbumId == request.AlbumId).ToList();

            var imagesResponse = _mapper.Map<List<ImageDto>>(allImages);

            return _response.ImagesRetrievedSuccessfully(imagesResponse, "Image RetrivedSuccesfully");
        }
    }
}
