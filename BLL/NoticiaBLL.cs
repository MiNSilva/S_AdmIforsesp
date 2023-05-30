using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DIAPOIO.MODEL;
using DIAPOIO.DAL;
using System.Data;

namespace DIAPOIO.BLL
{
    public class NoticiaBLL
    {
        public void AtualizaNoticia(NoticiaModel noticia, int operacao)
        {
            NoticiaDAL obj = new NoticiaDAL();
            obj.AtualizaNoticia(noticia, operacao);
        }

        public List<NoticiaModel> CarregaNoticiaAprovacao(int IdUsuario)
        {
            NoticiaDAL obj = new NoticiaDAL();
            return obj.CarregaNoticiaAprovacao(IdUsuario);
        }

        public void AlteraSituacaoNoticia(NoticiaModel noticia)
        {
            NoticiaDAL obj = new NoticiaDAL();
            obj.AlteraSituacaoNoticia(noticia);
        }

        public DataSet CarregaTodasNoticias(string pesquisa)
        {
            NoticiaDAL obj = new NoticiaDAL();
            return obj.CarregaTodasNoticias(pesquisa);
        }

        //public DataSet CarregaNoticiasTop(int Qtde, int DeptoId)
        //{
        //    NoticiaDAL obj = new NoticiaDAL();
        //    return obj.CarregaNoticiasTop(Qtde, DeptoId);
        //}

        public DataSet CarregaNoticiasTop(int Qtde, int DeptoId, int NoticiaId)
        {
            NoticiaDAL obj = new NoticiaDAL();
            return obj.CarregaNoticiasTop(Qtde, DeptoId, NoticiaId);
        }



        public DataSet CarregaNoticiasHome(int Qtde)
        {
            NoticiaDAL obj = new NoticiaDAL();
            return obj.CarregaNoticiasHome(Qtde);
        }

        public DataSet CarregaNoticiaById(int Id)
        {
            NoticiaDAL obj = new NoticiaDAL();
            return obj.CarregaNoticiaById(Id);
        }

        //public NoticiaModel CarregaNoticiaById(NoticiaModel noticia)
        //{
        //    NoticiaDAL obj = new NoticiaDAL();
        //    return obj.CarregaNoticiaById(noticia);
        //}

        public DataSet CarregaMesAnoPublicado(int DeptoId, int Operacao)
        {
            NoticiaDAL obj = new NoticiaDAL();
            return obj.CarregaMesAnoPublicado(DeptoId, Operacao);
        }

        public DataSet CarregaMesAnoPublicadoTodos(int DeptoId, int Operacao)
        {
            NoticiaDAL obj = new NoticiaDAL();
            return obj.CarregaMesAnoPublicadoTodos(DeptoId, Operacao);
        }


        public DataSet CarregaCategPublicado(int DeptoId)
        {
            NoticiaDAL obj = new NoticiaDAL();
            return obj.CarregaCategPublicado(DeptoId);
        }

        public DataSet CarregaCategPublicadoTodos(int DeptoId)
        {
            NoticiaDAL obj = new NoticiaDAL();
            return obj.CarregaCategPublicadoTodos(DeptoId);
        }

        public DataSet CarregaNoticiaByCateg(int IdCateg)
        {
            NoticiaDAL obj = new NoticiaDAL();
            return obj.CarregaNoticiaByCateg(IdCateg);
        }

        public DataSet CarregaNoticiaByData(string Mes, string Ano, int DeptoId, int Operacao)
        {
            NoticiaDAL obj = new NoticiaDAL();
            return obj.CarregaNoticiaByData(Mes, Ano, DeptoId, Operacao);
        }

        public int VerificaUpld(string pesq, int num)
        {
            NoticiaDAL obj = new NoticiaDAL();
            return obj.VerificaUpld(pesq, num);            
        }
        public string DeptosUsuario(int Id)
        {
            NoticiaDAL obj = new NoticiaDAL();
            return obj.DeptosUsuario(Id);             
        }

        public void EmailAprovador(int Depto)
        {
            NoticiaDAL obj = new NoticiaDAL();
            obj.EmailAprovador(Depto);
        }

        public DataSet BuscaNoticia(string busca, int Depto, int Todas)
        {
            NoticiaDAL obj = new NoticiaDAL();
            return obj.BuscaNoticia(busca, Depto, Todas);
        }

    }
}
