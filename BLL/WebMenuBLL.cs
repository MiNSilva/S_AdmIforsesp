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
    public class WebMenuBLL
    {
        //public List<WebMenuModel> CarregaMenu(string idUsuario)
        //{
        //    WebMenuDAL obj = new WebMenuDAL();
        //    return obj.CarregaMenu(idUsuario);
        //}
        public DataSet CarregaMenu(string idUsuario)
        {
            WebMenuDAL obj = new WebMenuDAL();
            return obj.CarregaMenu(idUsuario);
        }
        //public List<WebMenuModel> CarregaMenuPermissoes(string idUsuario)
        //{
        //    WebMenuDAL obj = new WebMenuDAL();
        //    return obj.CarregaMenuPermissoes(idUsuario);
        //}

        public DataSet CarregaMenuPermissoes(string idUsuario, int operacao, string submenu)
        {
            WebMenuDAL obj = new WebMenuDAL();
            return obj.CarregaMenuPermissoes(idUsuario, operacao, submenu);
        }

        public void AtualizaMenu(WebMenuModel menu, int operacao)
        {
            WebMenuDAL obj = new WebMenuDAL();
            obj.AtualizaMenu(menu, operacao);
        }


        public int ValidaMenu(WebMenuModel menu, int operacao)
        {
            WebMenuDAL obj = new WebMenuDAL();
            return obj.ValidaMenu(menu, operacao);
        }

        //public DataSet AtualizaMenuUsuario(DataTable dtusuaruio)
        //{
        //    WebMenuDAL obj = new WebMenuDAL();
        //    return obj.AtualizaMenuUsuario(dtusuaruio);
        //}

        public DataSet SalvarSubmenu(int operacao, int idUsuario, int id_menu)
        {
            WebMenuDAL obj = new WebMenuDAL();
            return obj.SalvarSubmenu(operacao, idUsuario, id_menu);
        }
        public void ExcluirPermissoes(int idUsuario)
        {
            WebMenuDAL obj = new WebMenuDAL();
            obj.ExcluirPermissoes(idUsuario);
        }
    }
}
