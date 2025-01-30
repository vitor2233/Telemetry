using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using Telemetry.Domain.Contracts.Mqtt;
using Telemetry.Domain.Services;

namespace Telemetry.Infra.WebSockets;

public class WebSocketService : IWebSocketService
{
    private readonly List<WebSocket> _clients;

    public WebSocketService()
    {
        _clients = [];
    }

    public async Task AddClientAsync(WebSocket webSocket)
    {
        if (_clients.Contains(webSocket)) return;

        _clients.Add(webSocket);

        await ReceiveMessagesAsync(webSocket);
    }

    public Task RemoveClientAsync(WebSocket webSocket)
    {
        _clients.Remove(webSocket);
        return Task.CompletedTask;
    }

    public async Task SendToClientsAsync(LocationMessage location)
    {
        var locationJson = JsonSerializer.Serialize(location);
        var buffer = Encoding.UTF8.GetBytes(locationJson);

        foreach (var client in _clients)
        {
            if (client.State == WebSocketState.Open)
            {
                await client.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
    }

    private async Task ReceiveMessagesAsync(WebSocket webSocket)
    {
        var buffer = new byte[1024 * 4];

        while (webSocket.State == WebSocketState.Open)
        {
            var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

            if (result.MessageType == WebSocketMessageType.Close)
            {
                await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closed by the WebSocket service", CancellationToken.None);
                await RemoveClientAsync(webSocket);
            }
        }
    }
}