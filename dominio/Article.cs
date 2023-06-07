using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace domain
{
    public class Article
    {   
        public int ArticleId { get; set; }
        [DisplayName("Code")]
        public string ArticleCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [DisplayName("Brand")]
        public Brand ArticleBrand { get; set; }
        [DisplayName("Category")]
        public Category ArticleCategory { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public ImagenArticulo ArticleImage { get; set; }
    }
}
