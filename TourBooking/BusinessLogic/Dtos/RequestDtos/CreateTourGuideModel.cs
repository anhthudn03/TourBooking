using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dtos.RequestDtos
{
    public class CreateTourGuideModel
    {
        public string HoVaTen { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public int? VeId { get; set; }

    }
}
