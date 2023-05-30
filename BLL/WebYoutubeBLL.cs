using DIAPOIO.DAL;
using DIAPOIO.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.BLL
{
    public class WebYoutubeBLL
    {
        public DataSet CarregaVideo(int id)
        {
            WebYoutubeDAL obj = new WebYoutubeDAL();
            return obj.CarregaVideo(id);
        }
        public DataSet CarregaVideoHome()
        {
            WebYoutubeDAL obj = new WebYoutubeDAL();
            return obj.CarregaVideoHome();
        }
        public void AtualizaVideo(WebYoutubeModel util, int operacao)
        {
            WebYoutubeDAL obj = new WebYoutubeDAL();
            obj.AtualizaVideo(util, operacao);
        }
        public void Orderna(int Id, int Ordem, int Operacao)
        {
            WebYoutubeDAL obj = new WebYoutubeDAL();
            obj.Orderna(Id, Ordem, Operacao);
        }
        public int GetOrdem()
        {
            WebYoutubeDAL obj = new WebYoutubeDAL();
            return obj.GetOrdem();
        }
        public DataSet GetYoutubeById(int id)
        {
            WebYoutubeDAL obj = new WebYoutubeDAL();
            return obj.GetYoutubeById(id);
        }

    }
}
