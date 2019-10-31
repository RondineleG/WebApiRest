using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI.Domain;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/Aluno")]
    public class AlunoController : ApiController
    {


        /// <summary>
        ///  Buscar Todos Alunos
        /// </summary>
        /// <remarks>Retorna uma lista de alunos Json do banco de dados</remarks>
        /// <response code="500">Internal Server Error</response>
        // GET: api/Aluno/
        [HttpGet]
        [Route("Recuperar")]
        // [Authorize]
        public IHttpActionResult Recuperar()
        {
            try
            {
                AlunoModel aluno = new AlunoModel();

                var alunos = aluno.ListarAluno();

                return Ok(alunos);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        ///  Buscar Aluno Por ID
        /// </summary>
        /// <remarks>Retorna um Aluno do banco de dados</remarks>
        [HttpGet]
        [Route("Recuperar/{id:int}")]
        public IHttpActionResult RecuperarPorId(int id)
        {
            try
            {
                AlunoModel aluno = new AlunoModel();

                return Ok(aluno.ListarAluno(id).FirstOrDefault());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            
        }

        /// <summary>
        ///  Criar um novo Aluno
        /// </summary>
        /// <remarks>Criar um Aluno do banco de dados</remarks>
        [HttpPost]
        public IHttpActionResult Post(AlunoDTO aluno)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                AlunoModel _aluno = new AlunoModel();

                _aluno.Inserir(aluno);

                return Ok(_aluno.ListarAluno());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        ///  Atualizar Aluno 
        /// </summary>
        /// <remarks>Atualiza um Aluno do banco de dados</remarks>
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]AlunoDTO aluno)
        {
            try
            {
                AlunoModel _aluno = new AlunoModel();
                aluno.id = id;
                _aluno.Atualizar(aluno);

                return Ok(_aluno.ListarAluno(id).FirstOrDefault());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        
        /// <summary>
        ///  Deletar Aluno
        /// </summary>
        /// <remarks>Deleta um Aluno do banco de dados</remarks>
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                AlunoModel _aluno = new AlunoModel();
                _aluno.Deletar(id);

                return Ok("Deletado com Sucesso");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
