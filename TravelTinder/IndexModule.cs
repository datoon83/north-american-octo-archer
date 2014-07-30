using System.Collections.Generic;
using TravelTinder.Library;

namespace TravelTinder
{
    using Nancy;

    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = parameters =>
                {
                    return View["index", new QuestionModel(new GetQuestions().Get())];
                };

            Post["/Suggestion/"] = _ =>
                {
                    var destination = new DestinationModel("Paris", "and she's a bit of an 'eye-ful'. Oo err.");
                    return Response.AsJson(destination);
                };


            //Get["/questions/"] = _ =>
            //    {
            //        return Response.ASJ
            //    }

        }
    }

    public class DestinationModel
    {
        public DestinationModel(string location, string caption)
        {
            NameOfLocation = location;
            Caption = caption;
            Image = string.Format("{0}.jpg", location);
        }

        public string NameOfLocation { get; set; }
        public string Caption { get; set; }
        public string Image { get; set; }
    }

    public class QuestionModel
    {
        public QuestionModel(List<UserResponse> userResponses)
        {
            UserResponses = userResponses;
        }

        public List<UserResponse> UserResponses { get; set; }
    }

    public class GetQuestions
    {
        public List<UserResponse> Get()
        {
            return new List<UserResponse>
                {
                    new UserResponse("Sport", "Mexican wave, anyone?"),
                    new UserResponse("Music", "Grow your hair. Live forever. You Rock."),
                    new UserResponse("Nightlife", "For the party animals amongst us. Grrr."),
                    new UserResponse("Romance", "Mwah. Oh, you shouldn’t have..."),
                    new UserResponse("Culture", "Making us all, better people. Probably."),
                    new UserResponse("Food", "A feast for the eyes and stomach. Yum."),
                    new UserResponse("Adventure", "Hold on to your hats..."),
                    new UserResponse("Family", "Bring your kids. yes, even yours..."),
                    new UserResponse("Passports", "It's got to be sunny. Tell me it's going to be sunny. Please..."),
                    new UserResponse("Scenery", "More views than you can shake a stick at...")
                };
        }
    }

}