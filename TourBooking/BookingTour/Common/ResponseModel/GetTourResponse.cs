namespace BookingTourAPI.Common.ResponseModel
{
    public class GetTourResponse
    {
        public int Id { get; set; }
        public int KhachSanId { get; set; }
        public int NguoiTao { get; set; }
        public int NguoiSua { get; set; }
        public int LoaiTuorId { get; set; }
        public DateTime NgayKhoiHanh { get; set; }
        public string TenTour { get; set; }
        public string MoTa { get; set; }
        public double GiaTour { get; set; }
        public string SoNgay { get; set; }
        public string TrangThai { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgaySua { get; set; }
    }
}
