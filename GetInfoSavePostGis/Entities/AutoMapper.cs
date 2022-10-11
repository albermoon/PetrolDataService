using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetInfoSavePostGis.Entities
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<PetrolStation, PetrolStationMap>();
        }
    }
}
