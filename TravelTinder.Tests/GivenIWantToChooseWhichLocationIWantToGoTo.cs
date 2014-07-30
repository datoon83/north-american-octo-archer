using NUnit.Framework;
using System.Collections.Generic;
using TravelTinder.Library;

namespace TravelTinder.Tests
{
    public class GivenIWantToChooseWhichLocationIWantToGoTo
    {
        [Test]
        public void WhenIAskANumberOfQuestions_ThenIShouldReturnTheCorrectLocation()
        {
            var responses = new List<UserResponse>
                {
                    new UserResponse("Sport"),
                    new UserResponse("Music"),
                    new UserResponse("Nightlife"),
                    new UserResponse("Romance"),
                    new UserResponse("Culture"),
                    new UserResponse("Food"),
                    new UserResponse("Adventure"),
                    new UserResponse("Family"),
                    new UserResponse("Passports"),
                    new UserResponse("Scenery")
                };

            responses[0].Yes = false;
            responses[1].Yes = true;
            responses[2].Yes = true;
            responses[3].Yes = false;
            responses[4].Yes = false;
            responses[5].Yes = false;
            responses[6].Yes = false;
            responses[7].Yes = false;
            responses[8].Yes = false;
            responses[9].Yes = true;

            var result = new MatchMaker().FindMatch(responses);

            Assert.That(result, Is.EqualTo("Paris"));
        }
    }
}
