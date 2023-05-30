using DIAPOIO.DAL.DB;
using DIAPOIO.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.DAL
{
    public class WebMenuDAL
    {
        public DataSet CarregaMenu(string idUsuario)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebMenuCarrega", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }


        //public List<WebMenuModel> CarregaMenu(string idUsuario)
        //{
        //    using (var db = new Conexao())
        //    {
        //        var cmd = db.CriarComando("WebMenuCarrega", CommandType.StoredProcedure);
        //        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
        //        var dr = cmd.ExecuteReader();

        //        List<WebMenuModel> list = new List<WebMenuModel>();

        //        while (dr.Read())
        //        {
        //            WebMenuModel menu = new WebMenuModel();
        //            menu.ID_MENU = (int)dr["ID_MENU"];
        //            menu.DESCR_MENU = (string)dr["DESCR_MENU"];
        //            menu.NOME_MENU = (string)dr["NOME_MENU"];
        //            if (dr["HIERARQUIA_MENU"] != DBNull.Value)
        //                menu.HIERARQUIA_MENU = (string)dr["HIERARQUIA_MENU"];
        //            if (dr["LINK_MENU"] != DBNull.Value)
        //                menu.LINK_MENU = (string)dr["LINK_MENU"];
        //            list.Add(menu);
        //        }
        //        dr.Close();
        //        return list;
        //    }
        //}

        //public List<WebMenuModel> CarregaMenuPermissoes(string idUsuario)
        //{
        //    using (var db = new Conexao())
        //    {
        //        var cmd = db.CriarComando("WebMenuPermissoesUsuario", CommandType.StoredProcedure);
        //        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
        //        var dr = cmd.ExecuteReader();

        //        List<WebMenuModel> list = new List<WebMenuModel>();

        //        while (dr.Read())
        //        {
        //            WebMenuModel menu = new WebMenuModel();
        //            menu.ID_MENU = (int)dr["ID_MENU"];
        //            if (dr["HIERARQUIA_MENU"] != DBNull.Value)
        //                menu.HIERARQUIA_MENU = (string)dr["HIERARQUIA_MENU"];
        //            menu.DESCR_MENU = (string)dr["DESCR_MENU"];
        //            menu.PERMITIDO = (string)dr["Permitido"];
        //            list.Add(menu);
        //        }
        //        dr.Close();
        //        return list;
        //    }
        //}


        public DataSet CarregaMenuPermissoes(string idUsuario, int operacao, string submenu)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebMenuPermissoesUsuario", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@Operacao", operacao);
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                cmd.Parameters.AddWithValue("@submenu", submenu);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }


        public DataSet CarregaMenuPermissoes(DataTable dtusuaruio)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebMenuPermissoesUsuario", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@tab", dtusuaruio);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }


        public int ValidaMenu(WebMenuModel menu, int operacao)
        {
            int result = 0;
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebMenuValidacao", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@Operacao", operacao);
                cmd.Parameters.AddWithValue("@Id", menu.ID_MENU);
                cmd.Parameters.AddWithValue("@NomePesq", menu.DESCR_MENU);
                result = (int)cmd.ExecuteScalar();
                return result;
            }
        }

        public void AtualizaMenu(WebMenuModel menu, int operacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("[WebMenuAtualiza", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@operacao", operacao);
                cmd.Parameters.AddWithValue("@desc_menu", menu.DESCR_MENU);
                cmd.Parameters.AddWithValue("@id_menu", menu.ID_MENU);
                cmd.Parameters.AddWithValue("@link", menu.LINK_MENU);
                cmd.ExecuteNonQuery();
            }
        }

        public DataSet SalvarSubmenu(int operacao, int idUsuario, int idmenu)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebMenuUsuarioAtualiza", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@operacao", operacao);
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                cmd.Parameters.AddWithValue("@idmenu", idmenu);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public void ExcluirPermissoes(int idUsuario)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebMenuExcluiUsuarioEspecifico", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
