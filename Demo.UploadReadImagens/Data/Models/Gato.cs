namespace Demo.UploadReadImagens.Data.Models
{
    public class Gato
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Idade { get; set; }
        public int? ImageId { get; set; }
        public virtual Image? Image { get; set; }
    }
}
