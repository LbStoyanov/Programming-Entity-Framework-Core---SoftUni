namespace MusicHub
{
    using System;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Data.Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context = 
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //var result = ExportAlbumsInfo(context, 9);
            var result = ExportSongsAboveDuration(context, 4);
            Console.WriteLine(result);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder result = new StringBuilder();

            var allAlbums = context
                .Albums
                .Where(a => a.ProducerId.Value == producerId)
                .Include(a => a.Producer)
                .Include(a => a.Songs)
                .ThenInclude(a => a.Writer) 
                .ToList()
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs.Select(s => new
                    {
                        SongName = s.Name,
                        s.Price,
                        Writer = s.Writer.Name
                    })
                    .OrderByDescending(s => s.SongName)
                    .ThenBy(s => s.Writer)
                    .ToList(),
                    TotalPrice = a.Price
                })
                .OrderByDescending(a => a.TotalPrice)
                .ToArray();
                

            foreach (var album in allAlbums)
            {
                result.AppendLine($"-AlbumName: {album.AlbumName}");
                result.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                result.AppendLine($"-ProducerName: {album.ProducerName}");
                result.AppendLine($"-Songs:");
                int songCounter = 1;

                foreach (var song in album.Songs)
                {
                    result.AppendLine($"#{songCounter}")
                          .AppendLine($"SongName: {song.SongName}")
                          .AppendLine($"Price: {song.Price:f2}")
                          .AppendLine($"Writer: {song.Writer}");
                    
                    songCounter++;
                }

                result.AppendLine($"AlbumPrice: {album.TotalPrice:f2}");
            }


            return result.ToString().TrimEnd();
        }
         
        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder result = new StringBuilder();

            var songs = context
                .Songs     
                .Include(s => s.SongPerformers)
                .ThenInclude(sp => sp.Performer)
                .Include(s => s.Writer)
                .Include(s => s.Album)
                .ThenInclude(a =>a.Producer)
                .ToArray()
                .Where(s => s.Duration.TotalSeconds > duration)          
                .Select(s => new
                {
                    SongName = s.Name, 
                    PerformerFullName = s.SongPerformers
                        .Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}")
                        .FirstOrDefault(),
                    WriterName = s.Writer.Name,
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration.ToString("c")

                })
                .OrderBy(s => s.SongName)
                .ThenBy(s=>s.WriterName)
                .ThenBy(s=>s.PerformerFullName)
                .ToArray();

            int songCounter = 1;

            foreach (var song in songs)
            {
                result.AppendLine($"-Song #{songCounter}");
                result.AppendLine($"---SongName: {song.SongName}");
                result.AppendLine($"---Writer: {song.WriterName}");
                result.AppendLine($"---Performer: {song.PerformerFullName}");
                result.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                result.AppendLine($"---Duration: {song.Duration}");
                Console.WriteLine(result.ToString().TrimEnd());

                songCounter++;
            }


            return result.ToString().TrimEnd();
        }
    }
}
