public interface IDelete<ID>
{
    public Task Delete(ID id);
}