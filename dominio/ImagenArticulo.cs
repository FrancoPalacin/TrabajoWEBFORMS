namespace domain
{
    public class ImagenArticulo
    {
      
        public ImagenArticulo(int Id, int ArticleId, string ImageUrl) {
            this.Id = Id;
            this.ArticleId = ArticleId;
            this.ImageUrl = ImageUrl;
        }
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public string ImageUrl { get; set; }

        public override string ToString()
        {
            return ImageUrl;
        }
    }
}
