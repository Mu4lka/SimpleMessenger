using FluentMigrator;

namespace Infrastucture.Persistence.Migrations;

[Migration(1)]
public class AddedMessagesTable : Migration
{
    public override void Up()
    {
        Create.Table("Messages")
            .WithColumn("id").AsCustom("uuid").PrimaryKey()
            .WithColumn("content").AsString()
            .WithColumn("created_date").AsDateTime()
            .WithColumn("sequence_number").AsInt32();
    }

    public override void Down()
    {
        Delete.Table("Messages");
    }
}
