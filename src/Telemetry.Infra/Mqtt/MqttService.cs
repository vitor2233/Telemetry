using System;
using System.Text;
using System.Text.Json;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Protocol;
using Telemetry.Domain.Contracts.Mqtt;

namespace Telemetry.Infra.Mqtt;

public class MqttService : IMqttService
{
    private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };

    private readonly IMqttClient _mqttClient;

    public MqttService()
    {
        var factory = new MqttFactory();
        _mqttClient = factory.CreateMqttClient();
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

    private Task HandleIncomingMessage(MqttApplicationMessageReceivedEventArgs args)
    {
        var payload = Encoding.UTF8.GetString(args.ApplicationMessage.PayloadSegment);
        var location = JsonSerializer.Deserialize<LocationMessage>(payload, JsonOptions);

        Console.WriteLine($"Mensagem recebida: {location}");


        return Task.CompletedTask;
    }
}