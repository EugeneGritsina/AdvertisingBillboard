using AdvertisingBillboard.Domain;
using System.Collections.Generic;

namespace AdvertisingBillboard.Web.Models
{
    public class ManageDevicesViewModel
    {
        public IDevicesRepository devices { get; set; }
        public IUsersRepository users { get; set; }
    }
}