namespace Gallery.Dto
{
    public class ImageResponseDto : ParentResponseDto
    {
        public IEnumerable<ImageDto> Result { get; set; }
    }
}
