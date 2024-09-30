namespace RWFormsApi.Infrastructure.Abstract.CRUD;
public interface IUpdate<ID,RQ,RS>
{
    Task<RS> Update(ID id, RQ request);
}