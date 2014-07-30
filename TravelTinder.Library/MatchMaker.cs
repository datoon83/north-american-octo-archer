using System.Collections.Generic;
using System.Linq;

namespace TravelTinder.Library
{
    public class MatchMaker
    {
        private List<Location> _locations;

        public MatchMaker()
        {
            _locations = new List<Location>
                {
                    new Location("London",
                                 new List<Question>
                                     {
                                         new Question("Sport", 3),
                                         new Question("Music", 5),
                                         new Question("Nightlife", 4),
                                         new Question("Culture", 4),
                                         new Question("Family", 2),
                                         new Question("Scenery", 2)
                                     }),
                    new Location("Paris",
                                 new List<Question>
                                     {
                                         new Question("Music", 3),
                                         new Question("Romance", 5),
                                         new Question("Culture", 5),
                                         new Question("Food", 5),
                                         new Question("Passports", 10),
                                         new Question("Scenery", 3)
                                     }),
                    new Location("Berlin",
                                 new List<Question>
                                     {
                                         new Question("Nightlife", 5),
                                         new Question("Culture", 3),
                                         new Question("Passports", 10),
                                         new Question("Scenery", 1)
                                     }),
                    new Location("Rome",
                                 new List<Question>
                                     {
                                         new Question("Romance", 4),
                                         new Question("Culture", 4),
                                         new Question("Food", 3),
                                         new Question("Passports", 10),
                                         new Question("Scenery", 4)
                                     }),
                    new Location("Manchester",
                                 new List<Question>
                                     {
                                         new Question("Sport", 4),
                                         new Question("Music", 4),
                                         new Question("Nightlife", 3),
                                         new Question("Family", 5)
                                     }),
                    new Location("Edingburgh",
                                 new List<Question>
                                     {
                                         new Question("Music", 2),
                                         new Question("Romance", 3),
                                         new Question("Culture", 2),
                                         new Question("Family", 4),
                                         new Question("Scenery", 4)
                                     }),
                    new Location("Lake District",
                                 new List<Question>
                                     {
                                         new Question("Adventure", 5),
                                         new Question("Family", 5),
                                         new Question("Scenery", 5)
                                     }),
                    new Location("Amsterdam",
                                 new List<Question>
                                     {
                                         new Question("Nightlife", 4),
                                         new Question("Culture", 3),
                                         new Question("Passports", 10)
                                     }),
                    new Location("Barcelona", new List<Question>
                        {
                            new Question("Sport", 5),
                            new Question("Nightlife", 3),
                            new Question("Culture", 4),
                            new Question("Food", 4),
                            new Question("Passports", 10),
                            new Question("Scenery", 3)
                        }),
                    new Location("Dubai", new List<Question> {new Question("Adventure", 4), new Question("Passports", 10)})
                };
        }

        public string FindMatch(List<UserResponse> questions)
        {
            var loc = new Dictionary<string, int>();

            foreach (var userResponse in questions.Where(x => x.Yes))
            {
                foreach (var location in _locations)
                {
                    if (location.RelevantQuestions.Any(x => x.Name == userResponse.ActualQuestion))
                    {
                        var question = location.RelevantQuestions.FirstOrDefault(x => x.Name == userResponse.ActualQuestion);
                        if (loc.ContainsKey(location.Name))
                            loc[location.Name] += question.Score;
                        else
                            loc.Add(location.Name, question.Score);
                    }
                }
            }

            var t = loc.OrderByDescending(x => x.Value);
            var result = t.First().Key;
            return result;
        }
    }
}