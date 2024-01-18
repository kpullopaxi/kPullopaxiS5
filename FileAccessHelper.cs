using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kPullopaxiS5
{
    public class FileAccessHelper
    {
        public static string GetocalFilePath(string filename){
            return System.IO.Path.Combine(FileSystem.AppDataDirectory, filename);

        }
    }
}
