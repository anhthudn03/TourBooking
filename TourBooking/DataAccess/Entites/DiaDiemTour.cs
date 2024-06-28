using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entites
{
    [Table("DiaDiemTour")]
    public class DiaDiemTour
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        [ForeignKey("TourId")]
        public Tour Tour { get; set; }
        public string TrangThai { get; set; }

        public int DiaDiemId { get; set; }
        [ForeignKey("DiaDiemId")]
        public DiaDiem DiaDiem { get; set; }
    }
}
