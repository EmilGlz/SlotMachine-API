namespace SlowMachine_API.Models.DTOs
{
    public class SlotResponse
    {
        public List<int> StopPositions { get; set; }
        public string[,] Screen { get; set; }
        public int TotalWins { get; set; }
        public List<WinDetails> WinDetails{ get; set; }

    }
}
