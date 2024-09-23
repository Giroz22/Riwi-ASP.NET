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
            .ForMember(
                dest => dest.User, 
                opt => opt.MapFrom( src => src.User )
            )
            .ForMember(
                dest => dest.Product, 
                opt => opt.MapFrom( src => src.Product )
            );
        CreateMap<OrderEntity, OrderToProductResponse>()
            .ForMember(
                dest => dest.User, 
                opt=> opt.MapFrom( src => src.User )
            );
        CreateMap<OrderEntity, OrderToUserResponse>()
            .ForMember(
                dest => dest.Product, 
                opt=> opt.MapFrom( src =>  src.Product )
            );  
        
        //Product
        CreateMap<ProductRequest, ProductEntity>();
        CreateMap<ProductEntity, ProductResponse>()
            .ForMember(
                dest => dest.Orders,
                opt => opt.MapFrom(src => src.Orders)
            );
        CreateMap<ProductEntity,ProductDTO>();

        //User
        CreateMap<UserRequest, UserEntity>();
        CreateMap<UserEntity, UserResponse>()
            .ForMember(
                dest => dest.Orders,
                opt => opt.MapFrom(src => src.Orders)
            );
        CreateMap<UserEntity,UserDTO>();
    }
}