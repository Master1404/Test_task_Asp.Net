namespace Test_task_Asp.Net.Models
{
    public class PairsViewModel
    {
        public IEnumerable<string> Pairs { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public uint TotalPairs { get; set; }
    }
}
