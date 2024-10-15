namespace CardApplication.Dtos
{
    public class CardDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string PhotoBase64 { get; set; }
    }
}
