using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.IO;

namespace DIAPOIO.UPLOAD
{
    public static class RepositorioArquivosHelper
    {
        public static List<Arquivo> GetArquivosRepositorio(HttpServerUtility server)
        {
            List<Arquivo> arquivos = new List<Arquivo>();

            DirectoryInfo diretorio = new DirectoryInfo(server.MapPath("~/images/GaleriaImagens/"));
            arquivos.AddRange(
                from a in diretorio.GetFiles()
                orderby a.CreationTime descending
                select new Arquivo()
                {
                    NomeArquivo = a.Name.Substring(a.Name.IndexOf("]") + 1),
                    CaminhoCompleto = a.FullName,
                    URL = "~/Repositorio/" + a.Name,
                    DataCriacao = a.CreationTime,
                    Tamanho = a.Length
                });

            return arquivos;
        }

        public static void ConfirmarUploadArquivos(HttpServerUtility server, HttpSessionState session)
        {
            if (session["ArquivosPreVisualizacao"] != null)
            {
                List<Arquivo> arquivos = (List<Arquivo>)session["ArquivosPreVisualizacao"];
                foreach (Arquivo arqImagem in arquivos)
                {
                    File.Move(arqImagem.CaminhoCompleto, server.MapPath("~/Repositorio/") +
                        new FileInfo(arqImagem.CaminhoCompleto).Name);
                }
                session["ArquivosPreVisualizacao"] = null;
            }
        }
    }
}