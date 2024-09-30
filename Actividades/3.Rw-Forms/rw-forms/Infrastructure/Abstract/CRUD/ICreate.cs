namespace RWFormsApi.Infrastructure.Abstract.CRUD;
public interface ICreate<RQ,RS>
{
    public Task<RS> Create(RQ request);
}