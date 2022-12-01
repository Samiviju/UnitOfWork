namespace Domain.Interfaces
{
    public interface IServiceLog
    {
        Task GravarLogAsync(object log, Guid identificador);
    }
}