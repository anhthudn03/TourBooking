using DataAccess.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dtos
{
    public class GioHangModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TourId { get; set; }
        public string TrangThai { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgaySua { get; set; }
    }
}
