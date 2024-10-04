using RWFormsApi.API.DTOs.Response;
using RWFormsApi.Domain.Entities;
using RWFormsApi.Infrastructure.Abstract.CRUD;

namespace RWFormsApi.Infrastructure.Abstract;
public interface IFormService : 
    IGetAll<FormResponse>,
    IGetById<string,FormResponse>,
    ICreate<FormRequest,FormResponse>,
    IUpdate<string,FormRequest,FormResponse>,
    IDelete<string>
{
    
}