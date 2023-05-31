using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;

namespace YouTubeLoader.Commands
{
    public class InfoCommand : ICommand
    {
        public void Run(string videoLink)
        {
            try
            {
                YoutubeClient client = new();
                var video = client.Videos.GetAsync(videoLink).Result;
                Console.WriteLine($"Title:\n{video.Title}");
                Console.WriteLine($"Description:\n{video.Description}");
            }
            catch( ArgumentException )
            {
                Console.WriteLine("Error: invalid argument. Check link it may be incorrect");
            }
            catch( Exception e )
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
}
