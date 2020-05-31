using System;
using System.Collections.Generic;
using WebAPI.Repository;

namespace WebAPI.Models
{     /// <summary>
      ///  Classe responsavel por unir classe AlunoDTO com AludoDAO para manipular os dados 
      /// </summary>
    public class AlunoModel
    {
        /// <summary>
        ///  Buscar Todos Alunos
        /// </summary>
        /// <remarks>Retorna uma lista de alunos Json do banco de dados</remarks>
        public List<Aluno> ListarAluno(int? id = null)
        {
            try
            {
                var alunoBD = new AlunoRepository();
                return alunoBD.ListarAlunosDB(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar Alunos: Erro => {ex.Message}");
            }
        }

        /// <summary>
        ///  Criar um novo Aluno
        /// </summary>
        /// <remarks>Criar um Aluno do banco de dados</remarks>
        public void Inserir(Aluno aluno)
        {
            try
            {
                var alunoBD = new AlunoRepository();
                alunoBD.InserirAlunoDB(aluno);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao Inserir Aluno: Erro => {ex.Message}");
            }
        }

        /// <summary>
        ///  Atualizar Aluno Por ID
        /// </summary>
        /// <remarks>Atualiza um Aluno do banco de dados</remarks>
        public void Atualizar(Aluno aluno)
        {
            try
            {
                var alunoBD = new AlunoRepository();
                alunoBD.AtualizarAlunoDB(aluno);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao Atualizar Aluno: Erro => {ex.Message}");
            }
        }

        /// <summary>
        ///  Deletar Aluno 
        /// </summary>
        /// <remarks>Deleta um Aluno do banco de dados</remarks>
        public void Deletar(int id)
        {
            try
            {
                var alunoBD = new AlunoRepository();
                alunoBD.DeletarAlunoDB(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao Deletar Aluno: Erro => {ex.Message}");
            }
        }

    }
}