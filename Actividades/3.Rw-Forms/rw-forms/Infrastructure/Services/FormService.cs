using MongoDB.Driver;
using RWFormsApi.Domain.Entities;
using RWFormsApi.Infrastructure.Abstract;

namespace RWFormsApi.Infrastructure.Services;

public class FormService : IFormService
{
    private readonly IMongoCollection<FormEntity> _formCollection;

    public FormService(IMongoDatabase database)
    {
        _formCollection = database.GetCollection<FormEntity>("Forms");
    }

    public async Task<List<FormEntity>> GetAllAsync()
    {
        return await _formCollection.Find(p => true).ToListAsync();
    }
}