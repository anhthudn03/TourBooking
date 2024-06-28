namespace BookingTourAPI.Common.RequestModel
{
    public class CreateTourGuideRequest
    {
        public string HoVaTen { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public int? VeId { get; set; }
    }
}
