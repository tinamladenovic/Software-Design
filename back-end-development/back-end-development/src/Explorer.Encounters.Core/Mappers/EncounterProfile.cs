using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using AutoMapper;
using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.Core.Domain;

namespace Explorer.Encounters.Core.Mappers
{
    public class EncounterProfile : Profile
    {
        public EncounterProfile()
        {
            CreateMap<EncounterCoordinateDto, Coordinate>().ReverseMap();
            CreateMap<EncounterDto, Encounter>().ReverseMap();
            CreateMap<EncounterExecutionDto, EncounterExecution>().ReverseMap();
        }
    }
}
