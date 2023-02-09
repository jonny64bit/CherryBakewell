namespace CherryBakewell.Web.Models;

public class GeneralJsonMessage<T>
{
    public string Result { get; set; }
    public T Detail { get; set; }
}
