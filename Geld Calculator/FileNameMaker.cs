using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geld_Calculator
{
    class FileNameMaker
    {
        public string MakeUnique(string path)
        {
            string fileName = System.IO.Path.GetFileNameWithoutExtension(path);
            string fileExt = System.IO.Path.GetExtension(path);

            for (int i = 1; ; ++i)
            {
                if (!System.IO.File.Exists(path))
                {
                    return path;
                }

                string prefix = "";
                if (i < 10)
                {
                    prefix = "000";
                }
                else if (i < 100)
                {
                    prefix = "00";
                }
                else if (i < 1000)
                {
                    prefix = "0";
                }
                path = System.IO.Path.Combine(fileName + "_" + prefix + i + fileExt);
            }
        }
    }
}
