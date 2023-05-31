using YoutubeExplode;
using YoutubeExplode.Converter;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;
using YouTubeLoader.Commands;

namespace YouTubeLoader
{
    internal class Program
    {

        static void Main(string[] args)
        {
            InputManager input = new( args );
            Commander? commander;
            if (input.IsInfoCommand)
                commander = new(new InfoCommand(), input.Link);
            else
                commander = new(new DownloadCommand(), input.Link);
            commander?.Run();
        }
    }
}