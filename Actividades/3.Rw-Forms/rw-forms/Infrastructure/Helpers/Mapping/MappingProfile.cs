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
        CreateMap<FormEntity, FormResponse>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src=>src.Status.ToString()));
        CreateMap<FormRequest, FormEntity>();

        //Section
        CreateMap<SectionEntity, SectionResponse>();
        CreateMap<SectionRequets, SectionEntity>();

        //Question
        CreateMap<QuestionEntity, QuestionResponse>()
            .ForMember(dest=>dest.TypeQuestion, opc=>opc.MapFrom(src=>src.TypeQuestion.ToString()));
        CreateMap<QuestionRequest, QuestionEntity>();
    }
}