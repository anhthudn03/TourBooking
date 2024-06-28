using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entites
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TenDangNHap { get; set; }

        [Required]
        public string MatKhau { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string ChucVu { get; set; }

        [Required]
        public DateTime NgayTao { get; set; }

        [Required]
        public DateTime NgaySua { get; set; }

        // Additional user-specific properties
        public string HoVaTen { get; set; }

        public DateTime NgaySinh { get; set; }

        public string DiaChi { get; set; }

        public string SDT { get; set; }
        public string TrangThai { get; set; }
    }
}
