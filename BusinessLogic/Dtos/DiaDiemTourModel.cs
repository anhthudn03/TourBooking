using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dtos
{
    public class DiaDiemTourModel
    {
        public int Id { get; set; }
        public int TourId { get; set; }

        public int DiaDiemId { get; set; }
    }
}
