namespace API.Dtos
{
    public class ProductToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }   
        public string? PictureUrl { get; set; }
        public string? ProductType{ get; set; }
        public int ProductTypeId{ get; set; }
        public string? ProductBrand { get; set; }
        public int ProductBrandId { get; set; }

    }
}