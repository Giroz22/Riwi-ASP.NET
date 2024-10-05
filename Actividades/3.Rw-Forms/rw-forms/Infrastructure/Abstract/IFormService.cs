using RWFormsApi.API.DTOs.Request;
using RWFormsApi.API.DTOs.Response;
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