namespace Utils
{
    public static class ApplicationConfig
    {
        private static EnvironmentConfig environmentConfig = new();

        public static string GetKeyPasswordVault()
        {
            var keySecretsManager = environmentConfig.AppSettingsFileSettings["ChaveCofreDeSenhas"];

            if (string.IsNullOrEmpty(keySecretsManager))
                throw new ArgumentException("Erro ao carregar a chave de configuração ChaveCofreDeSenhas.");

            return keySecretsManager;
        }

        public static string GetAwsRegion()
        {
            var regionAws = environmentConfig.AppSettingsFileSettings["AwsRegion"];

            if (string.IsNullOrEmpty(regionAws))
                throw new ArgumentException("Erro ao carregar a chave de configuração AwsRegion.");

            return regionAws;
        }
    }
}