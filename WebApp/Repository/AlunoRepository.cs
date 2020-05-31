using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebAPI.Models;

namespace WebAPI.Repository
{
    /// <summary>
    ///  Classe responsavel por acesso a banco de dados 
    /// </summary>
    public class AlunoRepository
    {
        /// <summary>
        ///  stringConexao 
        /// </summary>
        /// <remarks>string de Conexao com banco de dados</remarks>
        private string stringConexao = ConfigurationManager.ConnectionStrings["ConexaoDev"].ConnectionString;
        private IDbConnection conexao;

        /// <summary>
        ///  Construtor responsavel por abrir a conexao com banco de dados 
        /// </summary>
        public AlunoRepository()
        {
            conexao = new SqlConnection(stringConexao);
            conexao.Open();
        }


        /// <summary>
        ///  Metodo responsavel por listas aluno no banco de dados 
        /// </summary>
        public List<Aluno> ListarAlunosDB(int? id = null)
        {
            var listaAlunos = new List<Aluno>();

            try
            {
                IDbCommand selectCmd = conexao.CreateCommand();

                if (id == null)
                    selectCmd.CommandText = "select * from Alunos";
                else
                    selectCmd.CommandText = $"select * from Alunos where id = {id}";

                IDataReader resultado = selectCmd.ExecuteReader();
                while (resultado.Read())
                {
                    var alu = new Aluno
                    {
                        id = Convert.ToInt32(resultado["Id"]),
                        nome = Convert.ToString(resultado["nome"]),
                        sobrenome = Convert.ToString(resultado["sobrenome"]),
                        telefone = Convert.ToString(resultado["telefone"]),
                        ra = Convert.ToInt32(resultado["ra"]),
                    };

                    listaAlunos.Add(alu);
                }

                return listaAlunos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        /// <summary>
        ///  Metodo responsavel por Inserir aluno no banco de dados 
        /// </summary>
        public void InserirAlunoDB(Aluno aluno)
        {
            try
            {
                IDbCommand insertCmd = conexao.CreateCommand();
                insertCmd.CommandText = "insert into Alunos (nome, sobrenome, telefone, ra) values (@nome, @sobrenome, @telefone, @ra)";

                IDbDataParameter paramNome = new SqlParameter("nome", aluno.nome);
                insertCmd.Parameters.Add(paramNome);

                IDbDataParameter paramSobrenome = new SqlParameter("sobrenome", aluno.sobrenome);
                insertCmd.Parameters.Add(paramSobrenome);

                IDbDataParameter paramTelefone = new SqlParameter("telefone", aluno.telefone);
                insertCmd.Parameters.Add(paramTelefone);

                IDbDataParameter paramRa = new SqlParameter("ra", aluno.ra);
                insertCmd.Parameters.Add(paramRa);

                insertCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        /// <summary>
        ///  Metodo responsavel por Atualizar aluno no banco de dados 
        /// </summary>
        public void AtualizarAlunoDB(Aluno aluno)
        {
            try
            {
                IDbCommand updateCmd = conexao.CreateCommand();
                updateCmd.CommandText = "update Alunos set nome = @nome, sobrenome = @sobrenome, telefone = @telefone, ra = @ra where id = @id";

                IDbDataParameter paramNome = new SqlParameter("nome", aluno.nome);
                IDbDataParameter paramSobrenome = new SqlParameter("sobrenome", aluno.sobrenome);
                IDbDataParameter paramTelefone = new SqlParameter("telefone", aluno.telefone);
                IDbDataParameter paramRa = new SqlParameter("ra", aluno.ra);

                updateCmd.Parameters.Add(paramNome);
                updateCmd.Parameters.Add(paramSobrenome);
                updateCmd.Parameters.Add(paramTelefone);
                updateCmd.Parameters.Add(paramRa);

                IDbDataParameter paramID = new SqlParameter("id", aluno.id);
                updateCmd.Parameters.Add(paramID);

                updateCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        /// <summary>
        ///  Metodo responsavel por Deletar aluno no banco de dados 
        /// </summary>
        public void DeletarAlunoDB(int id)
        {
            try
            {
                IDbCommand DeleteCmd = conexao.CreateCommand();
                DeleteCmd.CommandText = "delete from Alunos where id = @id";

                IDbDataParameter paramID = new SqlParameter("id", id);
                DeleteCmd.Parameters.Add(paramID);

                DeleteCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}