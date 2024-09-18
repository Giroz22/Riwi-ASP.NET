using AutoMapper;
using ToDoApi.dtos.request;
using ToDoApi.dtos.response;
using ToDoApi.Models;

class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<TaskRequest, TaskEntity>();
        CreateMap<TaskEntity, TaskResponse>();
    }
}