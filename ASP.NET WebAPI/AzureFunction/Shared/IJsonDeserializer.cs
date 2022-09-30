using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AzureFunction.Shared;

public interface IJsonDeserializer
{
    Task<T> DeserializerAsync<T>(HttpRequest httpRequest);
}