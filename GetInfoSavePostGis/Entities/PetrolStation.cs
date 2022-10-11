using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GetInfoSavePostGis.Entities
{
    public class Alljson
    {
        [JsonPropertyName("Fecha")]
        public string DateOfUpdateService { get; set; }
        [JsonPropertyName("ListaEESSPrecio")]
        public List<PetrolStation> PetrolStation { get; set; }
    }
    public class PetrolStation
    {
        public int Id { get; set; }
        [JsonPropertyName("Rótulo")]
        public string Name { get; set; }
        [JsonPropertyName("Precio Gasoleo A")]
        public string? Diesel { get; set; }
        [JsonPropertyName("Precio Gasoleo Premium")]
        public string? DieselPlus { get; set; }
        [JsonPropertyName("Precio Gasoleo B")]
        public string? DieselB { get; set; }
        [JsonPropertyName("Precio Gasolina 95 E5")]
        public string? Petrol95 { get; set; }
        [JsonPropertyName("Precio Gasolina 98 E5")]
        public string? Petrol98 { get; set; }
        [JsonPropertyName("Horario")]
        public string? Schedule { get; set; }
        [JsonPropertyName("C.P.")]
        public string? PostalCode { get; set; }
        [JsonPropertyName("Latitud")]
        public string? Lat { get; set; }
        [JsonPropertyName("Longitud (WGS84)")]
        public string? Lon { get; set; }

    }
}
