using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizadorBilhetesECHService.Controller
{
    public class ComparaDiretorioController
    {
        public static String arquivoIgualDiretorio(string[] diretorios, String parametro, int dado)
        {
            String pasta = null;
            foreach (var anos in diretorios)
            {
                if (anos.ToString().Contains(parametro + dado))
                {
                    pasta = anos.ToString();
                }
            }

            return pasta;
        }



    }
}
