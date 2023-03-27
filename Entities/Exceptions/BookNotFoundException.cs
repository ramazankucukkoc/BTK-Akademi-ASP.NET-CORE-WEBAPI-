namespace Entities.Exceptions
{
    public sealed class BookNotFoundException : NotFoundException
    {
        //sealed new'lenemez değil kalıtım yapılamaz demektir.
        public BookNotFoundException(int id) : base($"The book with id : {id} could not found.")
        {
        }
    }
}
