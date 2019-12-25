namespace AdvertisingBillboard.Domain
{
    public class Device
    {
        public string Name { get; set; }
        public double Memory { get; set; }
        public User User { get; set; }
    }
}