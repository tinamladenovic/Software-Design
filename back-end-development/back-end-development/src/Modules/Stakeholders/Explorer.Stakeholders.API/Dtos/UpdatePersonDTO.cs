using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.API.Dtos
{
    public  class  UpdatePersonDTO
    {
        public long Id { get; set; }
        public long UserId { get; set; }    
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Motto { get; set; }
        public string Biography { get; set; }
        public string Image { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

    }
}
