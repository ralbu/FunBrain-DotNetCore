namespace FunBrainDomain
{
    public class GameResult
    {
        public GameResult(int winnerId, int randomNumber)
        {
            WinnerId = winnerId;
            RandomNumber = randomNumber;
        }
        public int WinnerId { get; set; }
        public int RandomNumber { get; set; }
    }
}
