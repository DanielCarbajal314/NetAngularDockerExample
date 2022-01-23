namespace Photo.Domain.Actions.Commands.ProcessImage
{
    public class ProcessImageCommandResponse
    {
        public string LargeThumbnailURL { get; set; }
        public string MediumThumbnailURL { get; set; }
        public string SmallThumbnailURL { get; set; }
    }
}