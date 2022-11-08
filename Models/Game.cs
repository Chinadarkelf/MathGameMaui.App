namespace MathGameMaui.Models
{
    public class Game
    {
        public int Id { get; set; }
        public GameOperation Type { get; set; }
        public int Score { get; set; }
        public DateTime DatePlayed { get; set; }
    }

    public enum GameOperation
    {
        ADDITION,
        SUBTRACTION,
        MULTIPLICATION,
        DIVISION,
    }
}
