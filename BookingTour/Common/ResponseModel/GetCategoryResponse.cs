namespace BookingTourAPI.Common.ResponseModel
{
    public class GetCategoryResponse
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public string TrangThai { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgaySua { get; set; }
    }
}
