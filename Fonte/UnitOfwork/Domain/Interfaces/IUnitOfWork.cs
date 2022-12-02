namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAdressRepository Address { get; }
        IEmailRepository Email { get; }
        IPersonRepository Person { get; }
        int Save();
    }
}
