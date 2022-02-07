namespace Photo.Domain.Actions.Commands.ProcessImage
{
    public class ProcessImageCommandResponse
    {
        public string LargeThumbnailURL { get; set; }
        public string MediumThumbnailURL { get; set; }
        public string SmallThumbnailURL { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string OriginalImageURL { get; set; }
        public bool Proccessed { get; set; }
    }
}