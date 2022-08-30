namespace TodayDrinkReasonBot.Models
{
    public class Holiday
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Holiday(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
