using DIAPOIO.MODEL;
using DIAPOIO.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DIAPOIO.BLL
{
    public class WebDownloadEmailBLL
    {
        public void AtualizaDownloadEmail(WebDownloadEmailModel downemail, int operacao)
        {
            WebDownloadEmailDAL obj = new WebDownloadEmailDAL();
            obj.AtualizaDownloadEmail(downemail, operacao);
        }

        public DataSet CarregaDownloadEmailUrl(string url)
        {
            WebDownloadEmailDAL obj = new WebDownloadEmailDAL();
            return obj.CarregaDownloadEmailUrl(url);
        }

        public DataSet CarregaDownloadAnexos(int EmailRespostaId)
        {
            WebDownloadEmailDAL obj = new WebDownloadEmailDAL();
            return obj.CarregaDownloadAnexos(EmailRespostaId);
        }

        public DataSet CarregaDownloadAnexosId(int downloadEmailId)
        {
            WebDownloadEmailDAL obj = new WebDownloadEmailDAL();
            return obj.CarregaDownloadAnexosId(downloadEmailId);
        }
    }

    
}
