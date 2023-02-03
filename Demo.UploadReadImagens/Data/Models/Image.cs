namespace Demo.UploadReadImagens.Data.Models
{
    public class Image
    {
        public int Id { get; set; }
        public byte[]? Dados { get; set; }
        public string? ContentType { get; set; }
    }
}
