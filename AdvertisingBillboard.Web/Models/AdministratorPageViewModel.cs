using AdvertisingBillboard.Domain;

namespace AdvertisingBillboard.Web.Models
{
    public class AdministratorPageViewModel
    {   
        public UserViewModel[] Users { get; set; }
        public Device[] Devices { get; set; }
        public Video[] Videos { get; set; }
        
    }
}