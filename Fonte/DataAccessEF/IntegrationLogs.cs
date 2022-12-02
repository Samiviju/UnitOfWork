using Lib.Comum.LogAplicacao;
using Newtonsoft.Json;
using Utils;

namespace DataAccessEF
{
    public class IntegrationLogs
    {
        public async Task GravarLogAsync(object log, Guid identificador)
        {
            Log modeloLog = new();
            modeloLog.IdentificadorAplicacao = "UnitOfwork";
            modeloLog.TipoLog = EnumTipoLog.Erro;
            modeloLog.NomeComponente = "UnitOfwork";
            modeloLog.Descricao = JsonConvert.SerializeObject(log);
            modeloLog.DataHoraInclusao = DateTime.Now;
            modeloLog.IdentificadorLogCustomizavel = identificador.ToString();

            ClienteLog clienteLog = new(ApplicationConfig.GetAwsRegion());
            await clienteLog.GravarLogAsync(modeloLog);
        }
    }
}