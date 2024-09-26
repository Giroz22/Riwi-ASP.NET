using AutoMapper;
using RiwiStore.API.DTOs;
using RiwiStore.Domain.Entities;

class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Order
        CreateMap<OrderRequest, OrderEntity>();
        CreateMap<OrderEntity, OrderResponse>();
        
        //Product
        CreateMap<ProductRequest, ProductEntity>();
        CreateMap<ProductEntity, ProductResponse>();
        CreateMap<ProductEntity,ProductDTO>();

        //User
        CreateMap<UserRequest, UserEntity>();
        CreateMap<UserEntity, UserResponse>();
        CreateMap<UserEntity,UserDTO>();

        //Purchase
        CreateMap<PurchaseRequest, PurchaseEntity>();
        CreateMap<PurchaseEntity, PurchaseResponse>();            
        CreateMap<PurchaseEntity,PurchaseToUserReponse>();
    }
}