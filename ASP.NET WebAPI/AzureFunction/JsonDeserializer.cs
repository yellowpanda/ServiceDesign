using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AzureFunction;

public class JsonDeserializer : IJsonDeserializer
{
    public async Task<T> DeserializerAsync<T>(HttpRequest httpRequest)
    {
        var jsonSerializerOptions = new JsonSerializerOptions
        {
            NumberHandling = JsonNumberHandling.AllowReadingFromString
        };
        return await JsonSerializer.DeserializeAsync<T>(httpRequest.Body, jsonSerializerOptions);
    }
}

