using RiwiStore.API.DTOs;

public interface IProductService :
    IGetAll<ProductResponse>,
    IGetById<int, ProductResponse>,
    ICreate<ProductRequest, ProductResponse>,
    IUpdate<int, ProductRequest,ProductResponse>,
    IDelete<int>
{
    
}