using System;
using System.Text;
using System.Text.Json;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Protocol;
using Telemetry.Application.Commands;
using Telemetry.Domain.Contracts.Mqtt;

namespace Telemetry.Infra.Mqtt;

public class MqttService : IMqttService
{
    private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };

    private readonly IMqttClient _mqttClient;
    private readonly IServiceProvider _serviceProvider;

    public MqttService(IServiceProvider serviceProvider)
    {
        var factory = new MqttFactory();
        _mqttClient = factory.CreateMqttClient();
        _serviceProvider = serviceProvider;
    }

    public async Task StartAsync()
    {
        var options = new MqttClientOptionsBuilder()
            .WithClientId("2b16a2b6-6cd5-41f0-9a8e-464a45bc6c94")
            .WithTcpServer("localhost", 1883)
            .Build();

        _mqttClient.ApplicationMessageReceivedAsync += HandleIncomingMessage;
        await _mqttClient.ConnectAsync(options, CancellationToken.None);

        await _mqttClient.SubscribeAsync("location/+", MqttQualityOfServiceLevel.AtMostOnce);
    }

    private async Task HandleIncomingMessage(MqttApplicationMessageReceivedEventArgs args)
    {
        var payload = Encoding.UTF8.GetString(args.ApplicationMessage.PayloadSegment);
        var location = JsonSerializer.Deserialize<LocationMessage>(payload, JsonOptions);

        if (location is not null)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                await mediator.Send(new LocationReceivedCommand(location));
            }
        }

        Console.WriteLine($"Mensagem recebida: {location}");
    }
}