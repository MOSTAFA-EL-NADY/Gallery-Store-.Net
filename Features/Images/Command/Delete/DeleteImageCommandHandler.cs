using Gallery.Dto;
using Gallery.Helper;
using Gallery.Interface;
using Gallery.Models;
using MediatR;

namespace Gallery.Features.Images.Command.Delete
{

    public class DeleteImageCommandHandler : IRequestHandler<DeleteImageCommand, ResponseDto>
    {
        private readonly IGRepository<Image> _imageRepo;
        private readonly ResponseHelper _response;
        public DeleteImageCommandHandler(IGRepository<Image> imageRepo, ResponseHelper response)
        {
            _imageRepo = imageRepo;
            _response = response;
        }

        public async Task<ResponseDto> Handle(DeleteImageCommand request, CancellationToken cancellationToken)
        {
            var image = _imageRepo.GetFirst(a => a.Id == request.Id);
            if (image == null)
                return _response.NotFound("Image Not Found");

            _imageRepo.Remove(image);
            _imageRepo.Save();
            File.Delete(image.Url);
            return _response.SavedSuccessfully("Image Deleted");
        }
    }
}
