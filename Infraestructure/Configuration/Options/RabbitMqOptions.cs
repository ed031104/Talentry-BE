namespace Infraestructure.Configuration.Options;

public sealed class RabbitMqOptions
{
    public const string SectionName = "RabbitMQ";

    public string Host { get; set; } = default!;

    public int Port { get; set; }

    public string Username { get; set; } = default!;

    public string Password { get; set; } = default!;

    public string VirtualHost { get; set; } = "/";
}