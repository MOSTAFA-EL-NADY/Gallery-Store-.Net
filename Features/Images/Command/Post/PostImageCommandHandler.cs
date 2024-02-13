using Gallery.Dto;
using Gallery.Helper;
using Gallery.Interface;
using Gallery.Models;
using Gallery.Services;
using MediatR;

namespace Gallery.Features.Images.Command.Post
{
    public class PostImageCommandHandler : IRequestHandler<PostImageCommand, ResponseDto>
    {
        private readonly IGRepository<Image> _imageRepository;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly int loggedInUserId;
        private readonly ResponseHelper _response;

        public PostImageCommandHandler(IWebHostEnvironment webHostEnvironment,
                                       IHttpContextAccessor contextAccessor,
                                       IGRepository<Image> imageRepository,
                                       ResponseHelper response)
        {
            this.webHostEnvironment = webHostEnvironment;
            _contextAccessor = contextAccessor;
            loggedInUserId = LoggedInUserProvider.GetLoggedInUserId(_contextAccessor);
            _imageRepository = imageRepository;
            _response = response;
        }

        public async Task<ResponseDto> Handle(PostImageCommand request, CancellationToken cancellationToken)
        {
            var image = new Image
            {
                AlbumId = request.AlbumId,
                Name = request.Image.FileName.Split(".")[0],
                Url = await UploadHelper.UploadImage(request.Image, webHostEnvironment, loggedInUserId.ToString()),
                Description = request.Description ?? null,
                Size = request.Image.Length,
                Type = Path.GetExtension(request.Image.FileName)?.TrimStart('.') ?? "",
            };

            _imageRepository.Add(image);
            _imageRepository.Save();

            return _response.SavedSuccessfully(image.Id, "Image Added Successfully");
        }
    }
}
