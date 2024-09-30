namespace RWFormsApi.Infrastructure.Abstract.CRUD;
public interface IGetAll<RS>
{
    public Task<IEnumerable<RS>> GetAll();
}