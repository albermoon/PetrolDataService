using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GetInfoSavePostGis.Entities
{
    public class PetrolStationMap
    {
            public int Id { get; set; }
            
            public string Name { get; set; }            
            public string? Diesel { get; set; }    
            public string? DieselPlus { get; set; }
            public string? DieselB { get; set; }
            public string? Petrol95 { get; set; }
            public string? Petrol98 { get; set; }
            public string? Schedule { get; set; }
            public string? PostalCode { get; set; }
            public string? Lat { get; set; }
            public string? Lon { get; set; }

    }
}
