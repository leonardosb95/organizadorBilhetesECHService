using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizadorBilhetesECHService.Util
{
    public class MoveArquivosUtil
    {

        public static void moverArquivo(FileInfo pathOrigem, String pathDestino, FileInfo arquivo)
        {
            try
            {
                File.Move(pathOrigem.FullName, pathDestino + "\\" + arquivo.Name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetBaseException());
                Console.WriteLine(e.Message);


            }



        }


    }
}
