using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using SimpleMessenger.DataAccess.Interfaces;
using SimpleMessenger.Domain;

namespace Infrastucture.Repositories;

public class MessagesRepository : IMessagesRepository
{
    public const string TableName = "public.\"Messages\"";
    private string? _connectionString;

    public MessagesRepository(IConfiguration configuration)
        => _connectionString = configuration.GetConnectionString("DefaultConnection");

    public async Task CreateAsync(Message message)
    {
        var sql = $"""
            INSERT INTO {TableName} (id, content, created_date, sequence_number)
            VALUES (@Id, @Content, @CreatedDate, @SequenceNumber)
            """;

        // TODO: Возможно лучше использовать пул соединений, чтобы каждый раз не открывать
        await using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();
        await connection.ExecuteAsync(sql, message);
        await connection.CloseAsync();
    }

    public async Task<ICollection<Message>> GetMessagesInLastMinutesAsync(int minutes)
    {
        var fixedTime = DateTime.Now.AddMinutes(-minutes).ToString("yyyy-MM-dd HH:mm:ss");

        var sql = $"""
            SELECT id AS Id, content AS Content, created_date AS CreatedDate, sequence_number AS SequenceNumber 
            FROM {TableName}
            WHERE created_date >= '{fixedTime}';
            """;
        
        await using var connection = new NpgsqlConnection(_connectionString);

        var messages = await connection.QueryAsync<Message>(sql);

        return messages.ToList();
    }
}