using AutoMapper;
using MongoDB.Driver;
using RWFormsApi.API.DTOs.Request;
using RWFormsApi.API.DTOs.Response;
using RWFormsApi.Domain.Entities;
using RWFormsApi.Infrastructure.Abstract;
using RWFormsApi.Util.Exceptions;

namespace RWFormsApi.Infrastructure.Services;

public class FormService : IFormService
{
    private readonly IMongoCollection<FormEntity> _formCollection;
    private readonly IMongoCollection<UserEntity> _UserCollection;
    private readonly IMapper _mapper;
    
    public FormService(IMongoDatabase database, IMapper mapper)
    {
        _formCollection = database.GetCollection<FormEntity>("Forms");
        _UserCollection = database.GetCollection<UserEntity>("Users");
        _mapper = mapper;
    }

    public async Task<IEnumerable<FormResponse>> GetAll()
    {
        IEnumerable<FormEntity> forms = await _formCollection.Find(p => true).ToListAsync();
        return _mapper.Map<List<FormResponse>>(forms);
    }

    public async Task<FormResponse> GetById(string id)
    {
        return _mapper.Map<FormResponse>(await FindForm(_formCollection, id));
    }

     public async Task<FormResponse> Create(FormRequest request)
    {
        FormEntity form = _mapper.Map<FormEntity>(request);
        form.User = await UserService.FindUser(_UserCollection, request.UserId);        

        await _formCollection.InsertOneAsync(form);
        return _mapper.Map<FormResponse>(form);
    }

    public async Task<FormResponse> Update(string id, FormRequest request)
    {
        FormEntity oldForm = await FindForm(_formCollection, id);
        oldForm.User = await UserService.FindUser(_UserCollection, request.UserId);
        FormEntity newForm = _mapper.Map(request, oldForm);

        await _formCollection.ReplaceOneAsync(f => f.Id == id, newForm);

        return _mapper.Map<FormResponse>(newForm);
    }

    public async Task Delete(string id)
    {
        FormEntity form = await FindForm(_formCollection,id);
        await _formCollection.DeleteOneAsync(f => f == form);
    }

    public static async Task<FormEntity> FindForm(IMongoCollection<FormEntity> _formCollection ,string id)
    {
        return await _formCollection.Find(f => f.Id == id).FirstOrDefaultAsync() ?? throw new IdNotFoundException("Form", id);
    }
}