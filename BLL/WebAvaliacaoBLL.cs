using DIAPOIO.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIAPOIO.DAL;

namespace DIAPOIO.BLL
{
    public class WebAvaliacaoBLL
    {
        public void AvaliacaoAtualiza(WebAvaliacaoModel avl)
        {
            WebAvaliacaoDAL obj = new WebAvaliacaoDAL();
            obj.AvaliacaoAtualiza(avl);
        }
      
    }

    public class WebAvaliacaoCategoriaBLL
    {
        public List<WebAvaliacaoCategoriaModel> CategoriaCarrega()
        {
            WebAvaliacaoCategoriaDAL obj = new WebAvaliacaoCategoriaDAL();
            return obj.CategoriaCarrega();
        }

        public void CategoriaAtualiza(WebAvaliacaoCategoriaModel cat, int nOperacao)
        {
            WebAvaliacaoCategoriaDAL obj = new WebAvaliacaoCategoriaDAL();
            obj.CategoriaAtualiza(cat, nOperacao);
        }
    }

    public class WebAvaliacaoQuestionarioBLL
    {
        public List<WebAvaliacaoQuestionarioModel> QuestionarioCarrega()
        {
            WebAvaliacaoQuestionarioDAL obj = new WebAvaliacaoQuestionarioDAL();
            return obj.QuestionarioCarrega();
        }

        public void QuestionarioAtualiza(WebAvaliacaoQuestionarioModel qst, int nOperacao)
        {
            WebAvaliacaoQuestionarioDAL obj = new WebAvaliacaoQuestionarioDAL();
            obj.QuestionarioAtualiza(qst, nOperacao);
        }
    }

    public class WebAvaliacaoPerguntaBLL
    {
        public List<WebAvaliacaoPerguntaModel> PerguntaCarrega(int nIdPergunta)
        {
            WebAvaliacaoPerguntaDAL obj = new WebAvaliacaoPerguntaDAL();
            return obj.PerguntaCarrega(nIdPergunta);
        }

        public void PerguntaAtualiza(WebAvaliacaoPerguntaModel per, int nOperacao)
        {
            WebAvaliacaoPerguntaDAL obj = new WebAvaliacaoPerguntaDAL();
            obj.PerguntaAtualiza(per, nOperacao);
        }
    }


    public class WebAvaliacaoModeloRespostaBLL
    {
        public List<WebAvaliacaoModeloRespostaModel> ModeloRespostaCarrega()
        {
            WebAvaliacaoModeloRespostaDAL obj = new WebAvaliacaoModeloRespostaDAL();
            return obj.ModeloRespostaCarrega();
        }
    }

    public class WebAvaliacaoRespostaBLL
    {
        public List<WebAvaliacaoRespostaModel> RespostaCarrega(int IdPergunta)
        {
            WebAvaliacaoRespostaDAL obj = new WebAvaliacaoRespostaDAL();
            return obj.RespostaCarrega(IdPergunta);
        }
    }
}
