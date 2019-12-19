namespace AdvertisingBillboard.Domain
{
    public class Device
    {
        public string deviceName { get; set; }
        public double memory { get; set; }
        public User user { get; set; }

        //DeviceGroup group { get; set; }
    }
}