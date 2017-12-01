namespace FunBrainDomain
{
    public class RoundResult
    {
        public RoundResult(int winnerId, int randomNumber, int roundsLeft)
        {
            WinnerId = winnerId;
            RandomNumber = randomNumber;
            RoundsLeft = roundsLeft;
        }

        public int WinnerId { get; private set; }
        public int RandomNumber { get; private set; }
        public int RoundsLeft { get; }
    }
}
