using organizadorBilhetesECHService.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizadorBilhetesECHService.Controller
{
    public class MoveArquivosController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("organizaPastas");

        public MoveArquivosController()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public static void moverArquivo(FileInfo arquivo, String[] diretorios, String parametro, int dado)
        {
            
            foreach (var horas in diretorios)
            {
                if (horas.ToString().Contains(parametro + dado))
                {

                    try
                    {
                        MoveArquivosUtil.moverArquivo(arquivo, @horas.ToString(), arquivo);
                    }
                    catch (Exception e)
                    {
                        log.Error(e);
                        Console.WriteLine(e.Message);

                    }

                }

            }

        }


    }
}
