public interface IGetAll<RS>
{
    public Task<IEnumerable<RS>> GetAll();
}