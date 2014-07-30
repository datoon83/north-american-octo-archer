namespace TravelTinder.Library
{
    public class UserResponse
    {
        public UserResponse(string question, string caption)
        {
            ActualQuestion = question;
            Caption = caption;
            Image = string.Format("{0}.jpg", question.ToLower());
        }

        public string ActualQuestion { get; set; }
        public string Caption { get; set; }
        public string Image { get; set; }
        public bool Yes { get; set; }
    }
}