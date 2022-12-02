using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using System.Text.Json.Nodes;

namespace Utils
{
    public class SecretsManager
    {
        public string ConnectionStringLocal { get; set; }

        public SecretsManager()
        {
            string keySecrestManager = ApplicationConfig.GetKeyPasswordVault();
            string secretReturned = string.Empty;

            IAmazonSecretsManager amazonSecretsManager = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(ApplicationConfig.GetAwsRegion()));

            GetSecretValueRequest secretValueRequest = new GetSecretValueRequest();
            secretValueRequest.SecretId = keySecrestManager;
            secretValueRequest.VersionStage = "AWSCURRENT";

            GetSecretValueResponse response = amazonSecretsManager.GetSecretValueAsync(secretValueRequest).Result;

            if (response.SecretString != null)
            {
                secretReturned = response.SecretString;
            }

            JsonObject secretRetrieved = JsonNode.Parse(secretReturned).AsObject();
            ConnectionStringLocal = secretRetrieved["ConnectionStringLocal"].ToString();
        }
    }
}