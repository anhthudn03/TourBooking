namespace BookingTourAPI.Common.RequestModel
{
    public class EmailBodyRequest
    {
        public string TenTour { get; set; }
        public DateTime NgayKhoiHanh { get; set; }
        public DateTime NgayDat {  get; set; }
        public double TongTien { get; set; }
        public int SoNguoi { get; set; }
    }
}
