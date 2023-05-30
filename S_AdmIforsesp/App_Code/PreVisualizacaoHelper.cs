using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.IO;
using System.Runtime.CompilerServices;

namespace DIAPOIO.UPLOAD
{
    public static class PreVisualizacaoHelper
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static string GetPathArquivoTemporario(HttpSessionState session, HttpServerUtility server, string nomeOriginal)
        {
            string caminho;

            if (session["Caminho"] == null)
            {
                caminho = server.MapPath("~/images/Galeria/") +
                String.Format("[{0}]", DateTime.Now.ToString("ddMMyyyyHHmmssfff")) + "\\";
                session["Caminho"] = caminho;
            }
            else
            {
                caminho = session["Caminho"].ToString();
            }

            session["pasta"] = caminho.Substring(caminho.IndexOf("["), 19);

            return caminho + nomeOriginal;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void AdicionarArquivoListaPreVisualizacao(HttpSessionState session, string caminhoArquivo)
        {
            List<Arquivo> arquivos;
            if (session["ArquivosPreVisualizacao"] != null)
            {
                arquivos = (List<Arquivo>)session["ArquivosPreVisualizacao"];
            
            }
            else
            {
                arquivos = new List<Arquivo>();
                session["ArquivosPreVisualizacao"] = arquivos;
            }

            FileInfo f = new FileInfo(caminhoArquivo);

            Arquivo arqImagem = new Arquivo();
            arqImagem.NomeArquivo = f.Name.Substring(f.Name.IndexOf("]") + 1);
            arqImagem.NomeArquivoData = f.Name;
            arqImagem.CaminhoCompleto = f.FullName;
            arqImagem.URL = "~/images/Galeria/" + caminhoArquivo.Substring(caminhoArquivo.IndexOf("["),19) + "/" + f.Name;
            arqImagem.DataCriacao = f.CreationTime;
            arqImagem.Tamanho = f.Length;
            arquivos.Add(arqImagem);
        }

        public static void RemoverArquivosListaPreVisualizacao(HttpSessionState session)
        {
            Arquivo pasta = new Arquivo();

            if (session["ArquivosPreVisualizacao"] != null)
            {
                
                List<Arquivo> arquivos = (List<Arquivo>)session["ArquivosPreVisualizacao"];

                foreach (Arquivo arqImagem in arquivos)
                {
                    Directory.Delete(arqImagem.CaminhoCompleto.Substring(0, arqImagem.CaminhoCompleto.LastIndexOf("]") + 1), true);
                    break;
                    //File.Delete(arqImagem.CaminhoCompleto);
                    //pasta.CaminhoCompleto = arqImagem.CaminhoCompleto.Substring(0, arqImagem.CaminhoCompleto.LastIndexOf("]") + 1);
                }
                
                session["ArquivosPreVisualizacao"] = null;
            }

            
        }
    }
}