namespace Test_task_Asp.Net.Core
{
    public interface IPairsProvider
    {
        Task<uint> CountAsync();
        Task<IEnumerable<string>> GetPairsAsync(int page);
    }
}
