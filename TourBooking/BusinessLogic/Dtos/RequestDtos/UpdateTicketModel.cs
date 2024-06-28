using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dtos.RequestDtos
{
    public class UpdateTicketModel
    {
        public int UserId { get; set; }
        public int TourId { get; set; }
        public string HoVaTen { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public string PTTT { get; set; }
        public DateTime NgaySua { get; set; }
        public double TongTien { get; set; }
    }
}
