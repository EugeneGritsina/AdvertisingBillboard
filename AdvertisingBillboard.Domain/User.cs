using System;
using System.Collections.Generic;

namespace AdvertisingBillboard.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Device> Devices { get; set; }
    }
}