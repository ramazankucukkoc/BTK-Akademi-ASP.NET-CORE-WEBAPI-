namespace Entities.Exceptions
{
    public abstract class NotFoundException : Exception
    {
        //ctor'u protected tanımlamamızın sebebi class abstract oldugu için newlenemez olması.
        protected NotFoundException(string message):base(message)
        {

        }
    }
}
