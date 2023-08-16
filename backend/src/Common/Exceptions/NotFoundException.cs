namespace Common.Exceptions;

public class NotFoundException : ApplicationException
{
    public NotFoundException(string name, object key) : base($"El objecto \"{name}\" con la llave {key} no fue encontrado;")
    {

    }
}