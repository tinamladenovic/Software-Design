using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos
{
    public class TourSaleConnectionDto
    {
        public int Id { get; set; }
        public long TourId { get; set; }
        public long SaleId { get; set; }
    }
}
