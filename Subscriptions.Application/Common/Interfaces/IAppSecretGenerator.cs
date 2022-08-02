namespace Subscriptions.Application.Common.Interfaces
{
    public interface IAppSecretGenerator
    {
        public string GenerateKey();
    }
}