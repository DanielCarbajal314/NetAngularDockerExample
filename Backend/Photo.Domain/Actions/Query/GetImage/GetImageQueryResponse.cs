namespace Photo.Domain.Actions.Query.GetImage
{
    public class GetImageQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OriginalImageURL { get; set; }
        public string LargeThumbnailURL { get; set; }
        public string MediumThumbnailURL { get; set; }
        public string SmallThumbnailURL { get; set; }
        public bool WasProcessed { get; set; }
    }
}