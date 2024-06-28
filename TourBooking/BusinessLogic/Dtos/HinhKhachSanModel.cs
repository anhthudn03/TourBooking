using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dtos
{
    public class HinhKhachSanModel
    {
        public int Id { get; set; }
        public int KhachSanId { get; set; }
        public string Url { get; set; }
       
    }
}
