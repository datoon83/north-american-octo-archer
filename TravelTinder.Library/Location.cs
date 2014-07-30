using System.Collections.Generic;

namespace TravelTinder.Library
{
    public class Location
    {
        public Location(string name, List<Question> questions)
        {
            Name = name;
            RelevantQuestions = questions;
        }

        public string Name { get; set; }
        public List<Question> RelevantQuestions { get; set; }
    }
}