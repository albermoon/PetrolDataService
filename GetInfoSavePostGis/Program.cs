// See https://aka.ms/new-console-template for more information

using System.Net.Http.Headers;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using GetInfoSavePostGis.Entities;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using GetInfoSavePostGis.BBDD;

class Program
{
    private static readonly HttpClient client = new HttpClient();

    static async Task Main(string[] args)
    {
        await ProcessRepositories();
    }
    static async Task ProcessRepositories()
    {
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        var steamTask = client.GetStreamAsync("https://sedeaplicaciones.minetur.gob.es/ServiciosRESTCarburantes/PreciosCarburantes/EstacionesTerrestres/");
        var stringTask = client.GetStringAsync("https://sedeaplicaciones.minetur.gob.es/ServiciosRESTCarburantes/PreciosCarburantes/EstacionesTerrestres/");
       
        //TODO create logging to controll possible error calling the service
        var repositories = await JsonSerializer.DeserializeAsync<Alljson>( await steamTask);
        var msg = await stringTask;
        if (repositories != null)
        {
            DbConnection.InsertInTable(repositories.PetrolStation);
        }
       
        Console.Write(msg);
    }
}


