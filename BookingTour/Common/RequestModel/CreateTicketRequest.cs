namespace BookingTourAPI.Common.RequestModel
{
    public class CreateTicketRequest
    {
        public int TourId { get; set; }
        public string HoVaTen { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public string PTTT { get; set; }
        public string TrangThai { get; set; }
        public int SoNguoi { get; set; }

        public double TongTien { get; set; }
    }
}
