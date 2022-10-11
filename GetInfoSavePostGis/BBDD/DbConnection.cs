using AutoMapper;
using GetInfoSavePostGis.Entities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetInfoSavePostGis.BBDD
{
    public static class DbConnection
    {
        static string connstring = String.Format("Server={0};Port={1};" +
            "User Id={2};Password={3};Database={4};",
            "localhost", "5432", "postgres",
            "qwe123ASD", "postgis");
        public static IMapper mapper;
         

        public static void InsertInTable(List<PetrolStation> petrols)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PetrolStation, PetrolStationMap>());
            mapper = new Mapper(config);

            try
            {
                // Making connection with Npgsql 
                NpgsqlConnection conn = new NpgsqlConnection(connstring);
                conn.Open();
                // sql statement
                string sql = " BEGIN; ";
                sql += "DELETE FROM petrols; ";
                sql += "INSERT INTO petrols (marca,diesel, diesel_plus,diesel_b, petrol95, petrol98, schedule, postal_code, coord) Values ";
                foreach (var p in petrols)
                {
                    //PetrolStationMap dto = mapper.Map<PetrolStationMap>(petrol);
                    //Console.WriteLine(dto.ToString());
                    var petrol = Mapp(p);
                  

                 //rememember if want change EPSG  must type ==> 'SRID=4326;POINT(-110 30)' this is WGS84
                    string coord = String.Format("POINT({0} {1})", petrol.Lon.Replace(',', '.'), petrol.Lat.Replace(',', '.'));

                    sql += String.Format(" ('{0}',{1},{2},{3}, {4},{5},'{6}',{7},'{8}' ) ,",
                        petrol.Name, petrol.Diesel, petrol.DieselPlus,
                        petrol.DieselB, petrol.Petrol95, petrol.Petrol98,
                        petrol.Schedule, petrol.PostalCode, coord);
                }

                sql = sql.Remove(sql.Length - 1);
                sql += "; COMMIT;";
                //sql = sql.Replace(",,",",null,");
                  

                // Execute command
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                command.ExecuteNonQuery();

                // since we only showing the result we don't need connection anymore
                conn.Close();
            }

            catch (Exception msg)
            {
                // something went wrong, and you wanna know why
                Console.WriteLine(msg.ToString());

            }
        }

        public static PetrolStationMap Mapp(PetrolStation petrol)
        {
            var test = new PetrolStationMap()
            {
                Petrol98 = petrol.Petrol98 == "" ? "0" : petrol.Petrol98.Replace(',', '.'),
                Petrol95 = petrol.Petrol95 == "" ? "0" : petrol.Petrol95.Replace(',', '.'),
                Diesel = petrol.Diesel == "" ? "0" : petrol.Diesel.Replace(',', '.'),
                DieselB = petrol.DieselB == "" ? "0" : petrol.DieselB.Replace(',', '.'),
                DieselPlus = petrol.DieselPlus == "" ? "0" : petrol.DieselPlus.Replace(',', '.'),
                Name = petrol.Name.Replace("'", " "),
                Schedule = petrol.Schedule == "" ? "0" : petrol.Schedule,
                Lat = petrol.Lat == "" ? "0" : petrol.Lat.Replace(',', '.'),
                Lon = petrol.Lon == "" ? "0" : petrol.Lon.Replace(',', '.'),
                PostalCode = petrol.PostalCode
            };
            return test;
        }


    }
}
