namespace Photo.Domain.Actions.Commands.RegisterImage
{
    public class RegisterImageCommandResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OriginalImageURL { get; set; }
    }
}