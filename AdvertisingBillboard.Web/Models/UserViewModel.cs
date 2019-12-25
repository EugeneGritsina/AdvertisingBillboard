using System;
using AdvertisingBillboard.Domain;

namespace AdvertisingBillboard.Web.Models
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Device[] Devices { get; set; }
    }
}