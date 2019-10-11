using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizadorBilhetesECHService.Util
{
    public class PegaArquivosUtil
    {

        public FileInfo[] getArquivo(String caminho)
        {
            DirectoryInfo diretorio = new DirectoryInfo(caminho);
            FileInfo[] arquivos = diretorio.GetFiles("*", SearchOption.AllDirectories);

            return arquivos;
        }



    }
}
