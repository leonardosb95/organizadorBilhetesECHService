using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizadorBilhetesECHService.Controller
{
    public class IsPastaExisteController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("organizaPastas");

        public IsPastaExisteController()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public static Boolean pastaExiste(string[] diretorios, String parametro, int dado)
        {
            Boolean resultado = false;
            try
            {
                resultado = Array.Exists(diretorios, x => x.Contains(Convert.ToString(parametro + dado)));
            }
            catch (Exception e)
            {
                log.Error(e);
                Console.WriteLine(e.Message);
            }

            return resultado;

        }


    }
}
