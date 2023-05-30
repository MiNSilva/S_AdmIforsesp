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
    public class WebCadastrosDAL
    {
        public DataSet CarregaCadastro()
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebCadastrosCarrega", CommandType.StoredProcedure);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet BuscaCadastro(string pesquisa)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebCadastroBusca", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@Busca", pesquisa);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }
        public WebCadastrosModel AtualizaCadastro(WebCadastrosModel cad, int operacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebCadastroAtualiza", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@operacao", operacao);
                cmd.Parameters.AddWithValue("@CadastroId", cad.CadastroId);
                cmd.Parameters.AddWithValue("@Nome", cad.Nome);
                cmd.Parameters.AddWithValue("@CPF", cad.CPF);
                cmd.Parameters.AddWithValue("@Email", cad.Email);
                cmd.Parameters.AddWithValue("@Senha", cad.Senha);
                cmd.Parameters.AddWithValue("@TipoCadastro", cad.TipoCadastro);
                cmd.Parameters.AddWithValue("@TipoServidor", cad.TipoServidor);
                cmd.Parameters.AddWithValue("@TipoStatus", cad.TipoStatus);
                cmd.Parameters.AddWithValue("@Cliente", cad.Cliente);
                cmd.Parameters.AddWithValue("@EstadoId", cad.EstadoId);
                cmd.Parameters.AddWithValue("@CidadeId", cad.CidadeId);
                cmd.Parameters.AddWithValue("@Endereco", cad.Endereco);
                cmd.Parameters.AddWithValue("@CEP", cad.CEP);
                cmd.Parameters.AddWithValue("@Bairro", cad.Bairro);
                cmd.Parameters.AddWithValue("@DDITel", cad.DDITel);
                cmd.Parameters.AddWithValue("@DDD", cad.DDDTel);
                cmd.Parameters.AddWithValue("@Telefone", cad.Telefone);
                cmd.Parameters.AddWithValue("@DDICel", cad.DDICel);
                cmd.Parameters.AddWithValue("@DDDCel", cad.DDDCel);
                cmd.Parameters.AddWithValue("@Celular", cad.Celular);
                cmd.Parameters.AddWithValue("@ReceberEmail", cad.ReceberEmail);
                cmd.Parameters.AddWithValue("@DataModificado", cad.DataModificado);

                cmd.Parameters.AddWithValue("@autorizainfoterceiros", cad.Autorizainfoterceiros);
                cmd.Parameters.AddWithValue("@NomeIndicacao", cad.NomeIndicacao);
                cmd.Parameters.AddWithValue("@TipoIndicacao", cad.TipoIndicacao);



                var result = cmd.ExecuteReader();

                if (result.Read())
                {
                    cad.Nome = (string)result["Nome"];
                    cad.Email = (string)result["Email"];
                    cad.Senha = (string)result["Senha"];
                    cad.CPF = (string)result["CPF"];
                    return cad;
                }
                else
                {
                    return null;
                }

            }
        }

        public WebCadastrosModel ValidaCadastro(WebCadastrosModel cad,string cpf1)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebCadastroValidacao", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@CPF", cad.CPF);
                cmd.Parameters.AddWithValue("@CPF1", cpf1);
                cmd.Parameters.AddWithValue("@Email", cad.Email);
                var result = cmd.ExecuteReader();
                if (result.Read())
                {
                    cad.Nome = (string)result["Nome"];
                    cad.Email = (string)result["Email"];
                    cad.TipoCadastro = (string)result["TipoCadastro"];
                    cad.TipoServidor = (string)result["TipoServidor"];
                    cad.TipoStatus = (string)result["TipoStatus"];
                    cad.Cliente = (int)result["Cliente"];
                    cad.EstadoId = (string)result["EstadoId"];
                    cad.CidadeId = (string)result["CidadeId"];
                    cad.Endereco = (string)result["Endereco"];
                    cad.CEP = (string)result["CEP"];
                    cad.Bairro = (string)result["Bairro"];
                    if (result["DDITel"] != DBNull.Value)
                        cad.DDITel = (string)result["DDITel"];
                    cad.DDDTel = (string)result["DDDTel"];
                    cad.Telefone = (string)result["Telefone"];
                    if (result["DDICel"] != DBNull.Value)
                        cad.DDICel = (string)result["DDICel"];
                    cad.DDDCel = (string)result["DDDCel"];
                    cad.Celular = (string)result["Celular"];
                    cad.Senha = (string)result["Senha"];
                    cad.CPF = (string)result["CPF"];
                    return cad;
                }
                else
                {
                    return null;
                }
            }
        }

        public WebCadastrosModel Autenticar(WebCadastrosModel cad)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebAutenticaCadastro", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@cpf", cad.CPF);
                cmd.Parameters.AddWithValue("@senha", cad.Senha);

                var result = cmd.ExecuteReader();

                if (result.Read())
                {
                    cad.CadastroId = (int)result["CadastroId"];
                    cad.Email = (string)result["Email"];
                    cad.Nome = (string)result["Nome"];
                    cad.Senha = (string)result["senha"];
                    return cad;
                }
                else
                {
                    return null;
                }
            }
        }

        public WebCadastrosModel RetornaCadastro(WebCadastrosModel cad)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebCadastroAreaRestrita", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@CadastroId", cad.CadastroId);
                var result = cmd.ExecuteReader();
                if (result.Read())
                {
                    
                    cad.Nome = (string)result["Nome"];
                    cad.Email = (string)result["Email"];
                    cad.Senha = (string)result["Senha"];
                    cad.CPF = (string)result["CPF"];
                    if (result["DDITel"] != DBNull.Value)
                        cad.DDITel = (string)result["DDITel"];
                    cad.DDDTel = (string)result["DDDTel"];
                    cad.Telefone = (string)result["Telefone"];
                    if (result["DDICel"] != DBNull.Value)
                        cad.DDICel = (string)result["DDICel"];
                    cad.DDDCel = (string)result["DDDCel"];
                    cad.Celular = (string)result["Celular"];
                    cad.TipoCadastro = (string)result["TipoCadastro"];
                    cad.TipoServidor = (string)result["TipoServidor"];
                    cad.TipoStatus = (string)result["TipoStatus"];
                    cad.Cliente = (int)result["Cliente"];
                    cad.CEP = (string)result["CEP"];
                    cad.Bairro = (string)result["Bairro"];
                    cad.Endereco = (string)result["Endereco"];
                    cad.EstadoId = (string)result["EstadoId"];
                    cad.CidadeId = (string)result["CidadeId"];
                    cad.ReceberEmail = (int)result["ReceberEmail"];
                    return cad;
                }
                else
                {
                    return null;
                }
            }
        }

        public WebCadastrosModel VerificarEmail(WebCadastrosModel cad)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebRecuperarEmailCadastro", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@CPF", cad.CPF);

                var result = cmd.ExecuteReader();
                if (result.Read())
                {
                    cad.CadastroId = (int)result["CadastroId"];
                    cad.Email = (string)result["Email"];
                    if (result["Senha"] != DBNull.Value)
                        cad.Senha = (string)result["Senha"];
                    return cad;
                }
                else
                {
                    return null;
                }
            }
        }

        public DataSet ValidaCliente(string cliente, string tipocad)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebValidacaoCliente", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@cliente", cliente);
                cmd.Parameters.AddWithValue("@tipocad", tipocad);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public void AtualizaSenha(WebCadastrosModel cad)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebSenhaAtualiza", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@Email", cad.Email);
                cmd.Parameters.AddWithValue("@Senha", cad.Senha);
                cmd.ExecuteNonQuery();
            }
        }

        public DataSet CarregaCadastroEstatisticas()
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebRelatorioCadastros", CommandType.StoredProcedure);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet CarregaRelCadastro(string DataIni, string DataFim)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebRelatorioCadastrosLista", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@dataIni", DataIni);
                cmd.Parameters.AddWithValue("@dataFim", DataFim);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet BuscaCadastroPorCPF(string CPF1)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebCadastroBuscaCPF", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@CPF1", CPF1);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }



       
    }
}

