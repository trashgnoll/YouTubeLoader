using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace YouTubeLoader.Commands
{
    public class DownloadCommand: ICommand
    {
        private async Task DownloadVideo(string link, string outputPath)
        {
            try
            {
                YoutubeClient client = new();
                var streamManifest = client.Videos.Streams.GetManifestAsync(link);
                var streamInfo = streamManifest.Result.GetMuxedStreams().GetWithHighestVideoQuality();
                await client.Videos.Streams.DownloadAsync(streamInfo, outputPath);
            }
            catch (Exception e)
            {
                Console.Write($"Error: {e.Message}");
            }
        }
        public void Run(string videoLink)
        {
            Console.WriteLine("Video is downloading to \"out.mp4\". Please wait!\nSorry for no progress indicator, i'm too lazy");
            Task t = DownloadVideo(videoLink, Path.Combine(Directory.GetCurrentDirectory(), "out.mp4"));
            t.Wait();
        }
    }
}
