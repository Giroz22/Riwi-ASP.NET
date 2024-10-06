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
            .ForMember(dest=>dest.TypeQuestion, opc=>opc.MapFrom(src=>src.TypeQuestion.ToString()))
            .ForMember(dest=>dest.Answer, opc=>opc.MapFrom(src=>src.Answer));            
        CreateMap<QuestionRequest, QuestionEntity>()
            .ForMember(dest => dest.Answer, opc => opc.MapFrom( src => MapAnswer(src)));
    }

     // Método auxiliar fuera de la expresión para manejar la lógica compleja
    private IAnswer MapAnswer(QuestionRequest src)
    {
        string nameClassAnswer = "RWFormsApi.Domain.Entities."+ src.TypeQuestion.ToString() + "AnswerEntity";

        // Obtén el tipo con el nombre que buscas
        Type type = Type.GetType(nameClassAnswer) ?? throw new Exception("\n Type not found \n");

        // Crea una instancia del tipo
        object obj = Activator.CreateInstance(type) ?? throw new Exception("\n Instance not found \n");

        // Realiza el pattern-matching y llama al método correspondiente
        if (obj is not IAnswer answer) throw new Exception("\n Type answer not found \n");
        
        return answer.CreateAnswer(src.Answer);
    }
}