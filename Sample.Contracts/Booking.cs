using System;

namespace Sample.Contracts
{
    public class Booking
    {
        public string Id { get; set; }
        public DateTimeOffset BookingDate { get; set; }
        public string Title { get; set; }
        public bool Premium { get; set; }
        public Member Member { get; set; }
        public Price Price { get; set; }
    }
}