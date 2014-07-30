namespace TravelTinder.Library
{
    public class Question
    {
        public Question(string name, int score)
        {
            Name = name;
            Score = score;
        }

        public string Name { get; set; }
        public int Score { get; set; }
    }
}