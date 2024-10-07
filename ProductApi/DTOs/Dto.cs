namespace ProductApi.DTOs
{
    public class Dto
    {
        public record CreateProduct(Guid Id, string Name, int Price, DateTime Createdtime);
        public record CreateProductDto(string Name, int Price);

        public record UpdateProductDto(Guid Id, string Name, int Price);


    }
}
