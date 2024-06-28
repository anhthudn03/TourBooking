using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entites
{
    [Table("GioHang")]

    public class GioHang
    {
        public int Id { get; set; }
       
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public int TourId { get; set; }
        [ForeignKey("TourId")]
        public Tour Tour { get; set; }

        public string TrangThai { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgaySua { get; set; }

    }
}
