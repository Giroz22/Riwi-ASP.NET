namespace RWFormsApi.Infrastructure.Abstract.CRUD;
public interface IDelete<ID>
{
    public Task Delete(ID id);
}