using DataAccessEF;
using Domain.Interfaces;

namespace Services
{
    public class ServiceLog : IServiceLog
    {
        private readonly IntegrationLogs _integrationLogs;

        public ServiceLog()
        {
            _integrationLogs = new();
        }

        public async Task GravarLogAsync(object log, Guid identificador)
        {
            await _integrationLogs.GravarLogAsync(log, identificador);
        }
    }
}