namespace Test_task_Asp.Net.Core
{
    public interface IApiService
    {
        Task<IEnumerable<string>> GetCryptoCurrencies();
    }
}
