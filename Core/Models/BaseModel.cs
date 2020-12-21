namespace Core.Models
{
    public class BaseModel
    {
        public SeoModel Seo { get; set; } = new SeoModel();
        public FooterModel Footer { get; set; } = new FooterModel();
    }
}