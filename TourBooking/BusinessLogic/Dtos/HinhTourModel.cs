using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dtos
{
    public class HinhTourModel
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public string? Url { get; set; }
       
    }
}
