namespace RWFormsApi.Util.Exceptions;
public class IdNotFoundException(string entity, string id) : 
    Exception(
        string.Format(ERROR_MESSAGE, entity, id)
    )
{
    private static readonly string ERROR_MESSAGE = "{0} with id {1} not found";
}