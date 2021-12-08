using Newtonsoft.Json;
 
 

namespace PersonalWeb.Models
{
    public class SettingWeb
    {
        public string WebTitle { get; set; }
        public string LogoSrc { get; set; }
        public string FullName { get; set; }
        public string ShortDescription { get; set; }
        public string DownloadCv { get; set; }
        public string Job { get; set; }
        public string ImageSrc { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this); 
    }
}