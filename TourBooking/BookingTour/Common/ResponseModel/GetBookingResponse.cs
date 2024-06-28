namespace BookingTourAPI.Common.ResponseModel
{
    public class GetBookingResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TourId { get; set; }
        public string TrangThai { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgaySua { get; set; }
    }
}
