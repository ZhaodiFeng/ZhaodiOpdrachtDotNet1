namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ReleaseDate = c.DateTime(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PublisherAlbums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PublisherId = c.Int(nullable: false),
                        AlbumId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Albums", t => t.AlbumId, cascadeDelete: true)
                .ForeignKey("dbo.Publishers", t => t.PublisherId, cascadeDelete: true)
                .Index(t => t.PublisherId)
                .Index(t => t.AlbumId);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        FoundingDate = c.DateTime(),
                        Profile = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrackAlbums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrackId = c.Int(nullable: false),
                        AlbumId = c.Int(nullable: false),
                        Squence = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Albums", t => t.AlbumId, cascadeDelete: true)
                .ForeignKey("dbo.Tracks", t => t.TrackId, cascadeDelete: true)
                .Index(t => t.TrackId)
                .Index(t => t.AlbumId);
            
            CreateTable(
                "dbo.Tracks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ReleaseDate = c.DateTime(),
                        Downloads = c.Int(),
                        Duration = c.Time(precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ArtistTracks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArtistId = c.Int(nullable: false),
                        TrackId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.ArtistId, cascadeDelete: true)
                .ForeignKey("dbo.Tracks", t => t.TrackId, cascadeDelete: true)
                .Index(t => t.ArtistId)
                .Index(t => t.TrackId);
            
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        BirthDay = c.DateTime(),
                        Bio = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrackGenres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrackId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .ForeignKey("dbo.Tracks", t => t.TrackId, cascadeDelete: true)
                .Index(t => t.TrackId)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrackGenres", "TrackId", "dbo.Tracks");
            DropForeignKey("dbo.TrackGenres", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.TrackAlbums", "TrackId", "dbo.Tracks");
            DropForeignKey("dbo.ArtistTracks", "TrackId", "dbo.Tracks");
            DropForeignKey("dbo.ArtistTracks", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.TrackAlbums", "AlbumId", "dbo.Albums");
            DropForeignKey("dbo.PublisherAlbums", "PublisherId", "dbo.Publishers");
            DropForeignKey("dbo.PublisherAlbums", "AlbumId", "dbo.Albums");
            DropIndex("dbo.TrackGenres", new[] { "GenreId" });
            DropIndex("dbo.TrackGenres", new[] { "TrackId" });
            DropIndex("dbo.ArtistTracks", new[] { "TrackId" });
            DropIndex("dbo.ArtistTracks", new[] { "ArtistId" });
            DropIndex("dbo.TrackAlbums", new[] { "AlbumId" });
            DropIndex("dbo.TrackAlbums", new[] { "TrackId" });
            DropIndex("dbo.PublisherAlbums", new[] { "AlbumId" });
            DropIndex("dbo.PublisherAlbums", new[] { "PublisherId" });
            DropTable("dbo.Genres");
            DropTable("dbo.TrackGenres");
            DropTable("dbo.Artists");
            DropTable("dbo.ArtistTracks");
            DropTable("dbo.Tracks");
            DropTable("dbo.TrackAlbums");
            DropTable("dbo.Publishers");
            DropTable("dbo.PublisherAlbums");
            DropTable("dbo.Albums");
        }
    }
}
