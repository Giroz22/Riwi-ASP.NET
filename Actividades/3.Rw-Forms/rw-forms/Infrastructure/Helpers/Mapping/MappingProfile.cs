using AutoMapper;
using RWFormsApi.API.DTOs.Request;
using RWFormsApi.API.DTOs.Response;
using RWFormsApi.Domain.Entities;

class MappingProfile : Profile
{
    public MappingProfile()
    {
        //User
        CreateMap<UserEntity, UserResponse>();
        CreateMap<UserRequest,UserEntity>();

        //Form
        CreateMap<FormEntity, FormResponse>();
        CreateMap<FormRequest, FormEntity>();
    }
}