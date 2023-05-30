using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DIAPOIO.DAL;
using DIAPOIO.MODEL;
using DIAPOIO.BLL.Autenticacao;

namespace DIAPOIO.BLL
{
    public class FuncoesBLL
    {
        public static string RemoveCarecteres(string texto, string[] caracteres)
        {
            if (texto == null) return texto;
            return caracteres.Aggregate(texto, (current, t) => current.Replace(t, ""));
        }

        public static int CHKCPF(string cVarCpf, int nChkOK)
        {
            int nSoma = 0;
            int nPeso = 2;
            string cDigito;

            cVarCpf = RemoveCarecteres(cVarCpf, new[] { "-", "." });

            for (int i = 9; i > 0; i--)
            {
                nSoma = nSoma + (Convert.ToInt32(cVarCpf.Substring(i - 1, 1)) * nPeso);
                nPeso = nPeso + 1;
            }

            if (nSoma == 0 && nChkOK == 1)
            {
                return 1;
            }

            nSoma = nSoma % 11;

            if (nSoma == 0 || nSoma == 1)
            {
                cDigito = "0";
            }
            else
            {
                cDigito = Convert.ToString(11 - nSoma).Substring(0, 1);
            }

            if (cVarCpf.Substring(9, 1) != cDigito)
            {
                return 0;
            }

            nSoma = 0;
            nPeso = 2;

            for (int i = 10; i > 0; i--)
            {
                nSoma = nSoma + (Convert.ToInt32(cVarCpf.Substring(i - 1, 1)) * nPeso);
                nPeso = nPeso + 1;
            }

            nSoma = nSoma % 11;

            if (nSoma == 0 || nSoma == 1)
            {
                if (cVarCpf.Substring(10, 1) != "0")
                {
                    return 0;
                }
            }
            else
            {
                nSoma = 11 - nSoma;
                if (cVarCpf.Substring(10, 1) != nSoma.ToString())
                {
                    return 0;
                }
            }

            return 1;
        }

        public static int Funcional(string Funcional, int _nChkOK, int tiposocio)
        {
            int nRetorno = 0;

            if (tiposocio == 1)
            {
                nRetorno = CHKRE(RemoveCarecteres(Funcional, new[] { "-", "." }), _nChkOK);
            }
            else
            {
                nRetorno = CHKSPPREV(RemoveCarecteres(Funcional, new[] { "-", "." }), _nChkOK);
            }

            return nRetorno;
        }

        public static int CHKRE(string cRe, int nChkOK)
        {
            int nSoma = 0;
            string ccDig = "";
            string cDig = cRe.Trim().Substring(cRe.Trim().Length - 1, 1);
            string vRe = (cRe.Trim().Substring(0, cRe.Trim().Length - 1)).PadLeft(6, '0');

            for (int i = 1; i < 7; i++)
            {
                nSoma += Convert.ToInt32(vRe.Substring(i - 1, 1)) * (8 - i);
            }

            nSoma = nSoma % 11;

            ccDig = Convert.ToString(11 - nSoma);

            if (ccDig == "11")
            {
                ccDig = "A";
            }
            else if (ccDig == "10")
            {
                ccDig = "0";
            }
            else
            {
                ccDig = ccDig.Substring(0, 1);
            }

            if (cDig != ccDig)
            {
                return 0;
            }

            return 1;
        }

        public static int CHKSPPREV(string cMatricula, int nChkOK)
        {
            //if (cMatricula.Trim().Length != 10)
            //{
            //    return 0;
            //}

            //if (cMatricula.Trim().Substring(0, 2) != "50" && cMatricula.Trim().Substring(0, 2) != "60")
            //{
            //    return 0;
            //}

            return 1;
        }
     
        public static string getEnderecoIP()
        {
            string strEnderecoIP;
            strEnderecoIP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (strEnderecoIP == null)
                strEnderecoIP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

            return strEnderecoIP;
        }

        public static int LiberaTravaRegistro(string Tabela, int Id, int Operacao)
        {
            return FuncoesDAL.LiberaTravaRegistro(Tabela, Id, Operacao);
        }

        public static int ValidaExclusao(string cTabela, string cCampo, int Id)
        {
            return FuncoesDAL.ValidaExclusao(cTabela, cCampo, Id);
        }

        public void Atividades(string url, string descricao, int usuariowebid)
        {
            WebAtividadeModel atividade = new WebAtividadeModel();
            atividade.DescAtividade = descricao;
            atividade.Usuariowebid = usuariowebid;
            atividade.Url = url;

            FuncoesDAL ativ = new FuncoesDAL();            
            ativ.AtualizaAtividade(atividade, 1);
        }

    }
}
