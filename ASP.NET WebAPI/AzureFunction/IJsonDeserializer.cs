using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AzureFunction;

public interface IJsonDeserializer
{
    Task<T> DeserializerAsync<T>(HttpRequest httpRequest);
}