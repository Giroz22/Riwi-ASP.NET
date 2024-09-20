using AutoMapper;
using RiwiStore.DTO;
using RiwiStore.Model;

class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Order
        CreateMap<OrderRequest, OrderEntity>();
        CreateMap<OrderEntity, OrderResponse>()
            .ForMember(dest => dest.User, opt => opt.MapFrom(src=>src.User))
            .ForMember(dest => dest.Product, opt => opt.MapFrom(src=>src.Product));
            
        CreateMap<ProductEntity, ProductDTO>();
        CreateMap<UserEntity, UserDTO>();

        //Product
        CreateMap<ProductRequest, ProductEntity>();
        CreateMap<ProductEntity, ProductResponse>();
        //User
        CreateMap<UserRequest, UserEntity>();
        CreateMap<UserEntity, UserResponse>();
    }
}