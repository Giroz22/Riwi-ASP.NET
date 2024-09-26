public interface IGetById<ID,RS>
{
    Task<RS> GetById(ID id);
}