using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Simple_Sharp_Graph
{
    static class SimpleFileDialog
    {
        public static string show()
        {
            var fileDialog = new OpenFileDialog();
            var result = fileDialog.ShowDialog();

            return result == true ? fileDialog.FileName : null;
        }
    }
}
