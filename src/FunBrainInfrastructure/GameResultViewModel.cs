namespace FunBrainInfrastructure
{
    public class GameResultViewModel
    {
        public GameResultViewModel(int userId, string winnerName, int randomNumber)
        {
            UserId = userId;
            WinnerName = winnerName;
            RandomNumber = randomNumber;
        }
        public int UserId { get; set; }
        public string WinnerName { get; }
        public int RandomNumber { get; set; }
    }
}
