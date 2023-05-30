using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DIAPOIO.DAL;
using DIAPOIO.MODEL;



namespace DIAPOIO.BLL
{
    public class UsuarioWebBLL
    {
        public UsuarioWebModel Logar(UsuarioWebModel usuario)
        {
            UsuarioWebDAL obj = new UsuarioWebDAL();
            return obj.Logar(usuario);
        }
        public DataSet CarregaUsuario()
        {
            UsuarioWebDAL obj = new UsuarioWebDAL();
            return obj.CarregaUsuario();
        }
        public DataSet CarregaUsuarioEspecifico(int IdUsuario)
        {
            UsuarioWebDAL obj = new UsuarioWebDAL();
            return obj.CarregaUsuarioEspecifico(IdUsuario);
        }
        public DataSet CarregaData(UsuarioWebModel usuario)
        {
            UsuarioWebDAL obj = new UsuarioWebDAL();
            return obj.CarregaData(usuario);
        }
        public DataSet CarregaUsuarioRelAtvidade(int usuariowebid, string dataIni, string dataFim)
        {
            UsuarioWebDAL obj = new UsuarioWebDAL();
            return obj.CarregaUsuarioRelAtvidade(usuariowebid, dataIni, dataFim);
        }
        public int AtualizaUsuario(UsuarioWebModel rev, int operacao)
        {
            UsuarioWebDAL obj = new UsuarioWebDAL();
            return obj.AtualizaUsuario(rev, operacao);
        }
        public void VerificaSenha(UsuarioWebModel usuario)
        {
            UsuarioWebDAL obj = new UsuarioWebDAL();
            obj.VerificarSenha(usuario);
        }
        public void AtualizaSenha(UsuarioWebModel usuario)
        {
            UsuarioWebDAL obj = new UsuarioWebDAL();
            obj.AtualizaSenha(usuario);
        }
        public int ValidaUsuario(UsuarioWebModel usuario, int operacao)
        {
            UsuarioWebDAL obj = new UsuarioWebDAL();
            return obj.ValidaUsuario(usuario, operacao);
        }

        public string ProcuraNomeUsuario(int usuarioid)
        {
            UsuarioWebDAL obj = new UsuarioWebDAL();
            return obj.ProcuraNomeUsuario(usuarioid);
        }
        public DataSet ProcuraUsuario(int usuarioid)
        {
            UsuarioWebDAL obj = new UsuarioWebDAL();
            return obj.ProcuraUsuario(usuarioid);
        }

        public void VerificarEmail(UsuarioWebModel usuario)
        {
            //usuario.Login = Funcoes.RemoveCarecteres(usuario.Login, new[] { "-", "." });
            UsuarioWebDAL obj = new UsuarioWebDAL();
            obj.VerificarEmail(usuario);
        }
       
    }
}
