using FluentMigrator;
using Infrastucture.Repositories;

namespace Infrastucture.Persistence.Migrations;

[Migration(20180430121800)]
public class AddedMessagesTable : Migration
{
    public override void Down()
    {
        Delete.Table("Messages");
    }

    public override void Up()
    {
        Create.Table("Messages")
            .WithColumn("id").AsCustom("uuid").PrimaryKey()
            .WithColumn("content").AsString()
            .WithColumn("created_date").AsDateTime()
            .WithColumn("sequence_number").AsInt32();
    }
}
