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
    public class WebCadastrosBLL
    {
        public DataSet CarregaCadastro()
        {
            WebCadastrosDAL obj = new WebCadastrosDAL();
            return obj.CarregaCadastro();
        }
        public WebCadastrosModel AtualizaCadastro(WebCadastrosModel cad, int operacao)
        {
            WebCadastrosDAL obj = new WebCadastrosDAL();
            return obj.AtualizaCadastro(cad, operacao);
        }
        public WebCadastrosModel ValidaCadastro(WebCadastrosModel cad, string cpf1)
        {
            WebCadastrosDAL obj = new WebCadastrosDAL();
            return obj.ValidaCadastro(cad, cpf1);
        }

        public void Autenticar(WebCadastrosModel cad)
        {
            cad.CPF = FuncoesBLL.RemoveCarecteres(cad.CPF, new[] { "-", "." });
            WebCadastrosDAL obj = new WebCadastrosDAL();
            obj.Autenticar(cad);
        }

        
        public WebCadastrosModel RetornaCadastro(WebCadastrosModel cad)
        {
            WebCadastrosDAL obj = new WebCadastrosDAL();
            return obj.RetornaCadastro(cad);
        }
        public void VerificarEmail(WebCadastrosModel cad)
        {
            //usuario.Login = Funcoes.RemoveCarecteres(usuario.Login, new[] { "-", "." });
            WebCadastrosDAL obj = new WebCadastrosDAL();
            obj.VerificarEmail(cad);
        }

        public DataSet BuscaCadastro(string pesquisa)
        {
            WebCadastrosDAL obj = new WebCadastrosDAL();
            return obj.BuscaCadastro(pesquisa);
        }

        public DataSet ValidaCliente(string cliente, string tipocad)
        {
            WebCadastrosDAL obj = new WebCadastrosDAL();
            return obj.ValidaCliente(cliente, tipocad);
        }

        public void AtualizaSenha(WebCadastrosModel cad)
        {
            WebCadastrosDAL obj = new WebCadastrosDAL();
            obj.AtualizaSenha(cad);
        }
        public DataSet CarregaCadastroEstatisticas()
        {
            WebCadastrosDAL obj = new WebCadastrosDAL();
            return obj.CarregaCadastroEstatisticas();
        }
        public DataSet CarregaRelCadastro(string DataIni, string DataFim)
        {
            WebCadastrosDAL obj = new WebCadastrosDAL();
            return obj.CarregaRelCadastro(DataIni, DataFim);
        }

        public DataSet BuscaCadastroPorCPF(string CPF1)
        {
            WebCadastrosDAL obj = new WebCadastrosDAL();
            return obj.BuscaCadastroPorCPF(CPF1);
        }
    }
}
