namespace Photo.Domain.Actions.Query.ListImages
{
    public class ListImagesQueryResponseItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OriginalImageURL { get; set; }
        public string LargeThumbnailURL { get; set; }
        public string MediumThumbnailURL { get; set; }
        public string SmallThumbnailURL { get; set; }
    }
}