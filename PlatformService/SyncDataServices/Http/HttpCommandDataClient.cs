using System.Text;
using System.Text.Json;
using PlatformService.Dtos;

namespace PlatformService.SyncDataService.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task SendPlatformToCommand(PlatformReadDto plat)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(plat),
                Encoding.UTF8,
                "application/json"
            );

            var resopnse = await _httpClient.PostAsync($"{_configuration["CommandService"]}", httpContent);

            if (resopnse.IsSuccessStatusCode)
            {
                Console.WriteLine("--> Snc POST TO CommandsService was OK!");
            }
            else
            {
                Console.WriteLine("--> Snc POST TO CommandsService was not OK!");
            }
        }
    }
}