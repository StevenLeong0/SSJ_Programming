namespace SeniorLearn.Models
{
    public class Dashboard
    {
        public int MemberId { get; set; }   // Primary key and Foreign key
        public bool Notifications { get; set; }
        public string FontSize { get; set; }
        public bool Captioning { get; set; }
        public string BrightnessMode { get; set; }

        public Member Member { get; set; }
    }
}