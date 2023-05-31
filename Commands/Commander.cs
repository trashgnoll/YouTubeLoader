using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeLoader.Commands
{
    public class Commander
    {
        public ICommand Command { get; set; }
        public string Link { get; set; }
        public Commander(ICommand command, string link)
        {
            Command = command;
            Link = link;
        }
        public void Run()
        {
            Command.Run(Link);
        }
    }
}
