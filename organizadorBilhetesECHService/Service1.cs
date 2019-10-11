using organizadorBilhetesECHService.Controller;
using organizadorBilhetesECHService.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace organizadorBilhetesECHService
{
    public partial class Service1 : ServiceBase
    {
        private Timer _timer;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("organizaPastas");

        public Service1()
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
        }

        protected override void OnStart(string[] args)
        {
            int time = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["time"]);
            _timer = new Timer(organizaBilhetesECH, null, 0, time);
            
        }

        protected override void OnStop()
        {
        }


        private void organizaBilhetesECH(object state)
        {


            string path1 = System.Configuration.ConfigurationManager.AppSettings["caminhoDosArquivos"];
            string path2 = System.Configuration.ConfigurationManager.AppSettings["arquivoCopiados"];


            PegaArquivosUtil get = new PegaArquivosUtil();
            pegaDiretorioUtil diretorio = new pegaDiretorioUtil();


            var listaArquivos = get.getArquivo(path1);

            if (listaArquivos.Count() > 0)
            {
                log.Info("Pegou lista de arquivos");
            }
            else
            {
                log.Info("Procurando arquivos........");
            }
            foreach (var arquivo in listaArquivos)
            {
                
                DateTime ultimaModificacao = arquivo.LastWriteTime;
                var anoDoArquivo = ultimaModificacao.Year;
                log.Info("Ano do arquivo: "+ anoDoArquivo);
                var mesDoArquivo = ultimaModificacao.Month;
                log.Info("Mes do arquivo: " + mesDoArquivo);
                var diaDoArquivo = ultimaModificacao.Day;
                log.Info("Dia do arquivo: " + diaDoArquivo);
                var horaDoArquivo = ultimaModificacao.Hour;
                log.Info("Hora do arquivo: " + horaDoArquivo);
                var diretorios = diretorio.getDiretorio(path2);
                log.Info("Pegou lista de diretorios");

                var possuiPastaAno = IsPastaExisteController.pastaExiste(diretorios, "Ano-", anoDoArquivo);

                if (possuiPastaAno)
                {
                    String pastaAno = ComparaDiretorioController.arquivoIgualDiretorio(diretorios, "Ano-", anoDoArquivo);

                    var diretoriosMes = diretorio.getDiretorio(pastaAno);
                    var possuiPastaMes = IsPastaExisteController.pastaExiste(diretoriosMes, "Mes-", mesDoArquivo);

                    if (possuiPastaMes)
                    {
                        String pastaMes = ComparaDiretorioController.arquivoIgualDiretorio(diretoriosMes, "Mes-", mesDoArquivo);

                        var diretoriosDia = diretorio.getDiretorio(pastaMes);
                        var possuiPastaDia = IsPastaExisteController.pastaExiste(diretoriosDia, "Dia-", diaDoArquivo);

                        if (possuiPastaDia)
                        {
                            String pastaDia = ComparaDiretorioController.arquivoIgualDiretorio(diretoriosDia, "Dia-", diaDoArquivo);

                            var diretoriosHora = diretorio.getDiretorio(pastaDia);
                            var possuiPastaHora = IsPastaExisteController.pastaExiste(diretoriosHora, "Hora-", horaDoArquivo);


                            if (possuiPastaHora)
                            {
                                log.Info("movendo arquivo para pasta");
                                MoveArquivosController.moverArquivo(arquivo, diretoriosHora, "Hora-", horaDoArquivo);
                            }
                            else
                            {
                                log.Warn("Criando pasta hora");
                                //CRIA PASTA HORA

                                var criaPastaHora = @pastaDia + "\\Hora-" + Convert.ToString(horaDoArquivo);
                                CriaPastaUtil.criaPasta(criaPastaHora);
                            }


                        }
                        else
                        {
                            log.Warn("Criando pasta dia");
                            //CRIA PASTA DIA
                            var criaPastaHora = @pastaMes + "\\Dia-" + Convert.ToString(diaDoArquivo);
                            CriaPastaUtil.criaPasta(criaPastaHora);

                        }

                    }
                    else
                    {
                        log.Warn("Criando pasta mês");
                        //CRIA PASTA MÊS
                        var criaPastaMes = @pastaAno + "\\Mes-" + Convert.ToString(mesDoArquivo);
                        CriaPastaUtil.criaPasta(criaPastaMes);

                    }
                }
                else
                {
                    log.Warn("Criando pasta ano");
                    //CRIA PASTA ANO
                    var criaPastaMes = path2 + "\\Ano-" + Convert.ToString(anoDoArquivo);
                    CriaPastaUtil.criaPasta(criaPastaMes);
                }

            }
        }


    }




}

