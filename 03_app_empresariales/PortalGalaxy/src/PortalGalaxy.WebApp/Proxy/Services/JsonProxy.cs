using System.Net.Http.Json;
using PortalGalaxy.Common.Response;
using PortalGalaxy.WebApp.Proxy.Interfaces;

namespace PortalGalaxy.WebApp.Proxy.Services;

public class JsonProxy : IJsonProxy
{
    private readonly HttpClient _httpClient;

    public JsonProxy()
    {
        _httpClient = new HttpClient() { BaseAddress = new Uri("https://localhost:7085")};
    }

    public async Task<ICollection<DepartamentoModel>> ListDepartamentos()
    {
        List<DepartamentoModel> departamentos = new();
        try
        {
            departamentos = await _httpClient.GetFromJsonAsync<List<DepartamentoModel>>("data/departamentos.json") ??
                            new List<DepartamentoModel>();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return departamentos;
    }

    public async Task<ICollection<DistritoModel>> ListDistritos(string codProvincia)
    {
        var distritos = await _httpClient.GetFromJsonAsync<List<DistritoModel>>("data/distritos.json") ??
                        new List<DistritoModel>();

        return distritos.Where(d => d.CodProvincia == codProvincia).ToList();
    }

    public async Task<ICollection<SituacionModel>> ListSituaciones()
    {
        List<SituacionModel> situaciones = new();
        try
        {
            situaciones = await _httpClient.GetFromJsonAsync<List<SituacionModel>>("data/situaciones.json") ??
                          new List<SituacionModel>();
            
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return situaciones;
    }

    public async Task<ICollection<ProvinciaModel>> ListProvincias(string codigoDpto)
    {
        var provincias = await _httpClient.GetFromJsonAsync<List<ProvinciaModel>>("data/provincias.json") ??
                         new List<ProvinciaModel>();

        return provincias.Where(p => p.CodigoDpto == codigoDpto).ToList();
    }
}