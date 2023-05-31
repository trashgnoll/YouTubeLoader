using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeLoader
{
    public interface ICommand
    {
        public void Run(string videoLink);
    }
}
