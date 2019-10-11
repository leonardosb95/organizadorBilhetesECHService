using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace organizadorBilhetesECHService.Util
{
    public class CriaPastaUtil
    {


        public static void criaPasta(string diretorio)
        {
            if (!Directory.Exists(diretorio))
            {

                Directory.CreateDirectory(diretorio);
            }

        }



    }
}
