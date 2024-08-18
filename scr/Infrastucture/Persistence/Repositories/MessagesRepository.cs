using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using SimpleMessenger.Domain;
using SimpleMessenger.Domain.Entities;

namespace Infrastucture.Persistence.Repositories;

public class MessagesRepository : IMessagesRepository
{
    public const string TableName = "public.\"Messages\"";
    private readonly string? _connectionString;

    public MessagesRepository(IConfiguration configuration)
        => _connectionString = configuration.GetConnectionString("DefaultConnection");

    public async Task CreateMessageAsync(Message message)
    {
        var sql = $"""
            INSERT INTO {TableName} (id, content, created_date, sequence_number)
            VALUES (@Id, @Content, @CreatedDate, @SequenceNumber)
            """;

        await using var connection = new NpgsqlConnection(_connectionString);
        await connection.ExecuteAsync(sql, message);
    }

    public async Task<ICollection<Message>> GetMessagesSentAfterAsync(DateTime sentAfter)
    {
        var sql = $"""
            SELECT id AS Id, content AS Content, created_date AS CreatedDate, sequence_number AS SequenceNumber 
            FROM {TableName}
            WHERE created_date >= @SentAfter;
            """;

        await using var connection = new NpgsqlConnection(_connectionString);
        var messages = await connection.QueryAsync<Message>(sql, new { SentAfter = sentAfter });

        return messages.ToList();
    }
}