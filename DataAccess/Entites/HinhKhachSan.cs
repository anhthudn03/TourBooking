using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entites
{
    [Table("HinhKhachSan")]
    public class HinhKhachSan
    {
        public int Id { get; set; }
        public int KhachSanId { get; set; }
        [ForeignKey("KhachSanId")]
        public KhachSan KhachSan { get; set; }

        public string? Url { get; set; }
      

    }
}
