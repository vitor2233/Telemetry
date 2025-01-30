using System.Net.WebSockets;
using Telemetry.Domain.Contracts.Mqtt;

namespace Telemetry.Domain.Services;

public interface IWebSocketService
{
    Task AddClientAsync(WebSocket webSocket);
    Task RemoveClientAsync(WebSocket webSocket);
    Task SendToClientsAsync(LocationMessage location);
}