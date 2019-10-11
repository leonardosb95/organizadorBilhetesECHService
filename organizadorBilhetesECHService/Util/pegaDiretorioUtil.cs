using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizadorBilhetesECHService.Util
{
    public class pegaDiretorioUtil
    {
        public string[] getDiretorio(String caminho)
        {
            string[] diretorios = Directory.GetDirectories(caminho);

            return diretorios;
        }

    }
}
