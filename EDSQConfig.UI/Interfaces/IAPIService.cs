namespace EDSQConfig.UI.Interfaces
{
    public interface IAPIService
    {
        Task<T> GetAsync<T>(string urlPath, string token = "", CancellationToken cancellationToken = new CancellationToken()) where T : class;
        Task<string> PostAsync(string urlPath, object postData, string token = "", CancellationToken cancellationToken = new CancellationToken());
    }
}
