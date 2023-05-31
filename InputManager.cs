using AngleSharp.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeLoader
{

    internal class InputManager
    {
        /// <summary>
        /// Link to the video. <b>First argument</b> or input. Must contain "youtu"
        /// </summary>
        public string Link = string.Empty;
        /// <summary>
        /// Command to run. <b>Second argument</b> or input. Must be 1 or 2. <u>If not 2 turns to 1</u>
        /// </summary>
        public bool IsInfoCommand = true;
        /// <summary>
        /// Input command: check fist argumen or ask for input
        /// </summary>
        /// <param name="args">Arguments from Main void</param>
        private void InputLink(string[] args)
        {
            if (args.Length >= 1 && args[0].Contains("youtu")) // sort of bad check
            {
                Link = args[0];
                return;
            }
            string? link = null;
            while (string.IsNullOrEmpty(link) || !link.Contains("youtu"))
            {
                Console.WriteLine("Enter link to YouTube video: ");
                link = Console.ReadLine();
            }
            if (link.StartsWith("https:\\\\"))
                link = "https:\\\\" + link;
            Link = link;
        }
        /// <summary>
        /// Input command: check second argumen or ask for input
        /// </summary>
        /// <param name="args">Arguments from Main void</param>
        private void InputCommand(string[] args)
        {
            if (args.Length >= 2 && args[1].Length == 1 && 
                    (args[1] == "1" || args[1] == "2" ) ) // sort of check
            {
                IsInfoCommand = (args[1] == "1");
                return;
            }
            Console.WriteLine("What to do?\n\t1: Show info\n\t2: Download to \"out.mp4\"");
            ConsoleKeyInfo command = Console.ReadKey();
            while ( command.KeyChar != '1' && command.KeyChar != '2' )
            {
                Console.WriteLine("What to do?\n\t1: Show info\n\t2: Download to \"out.mp4\"");
                command = Console.ReadKey();
            }
            IsInfoCommand = (command.KeyChar == '1');
        }
        /// <summary>
        /// Get link and command from args or ask for input
        /// </summary>
        /// <param name="args">Give me your args from Main void</param>
        public InputManager(string[] args)
        {
            InputLink(args);
            InputCommand(args);
        }
    }
}
