using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    /// <summary>
    ///  Classe responsavel por modelar propriedades do Alnuno 
    /// </summary>
    public class Aluno
    {

        /// <summary>
        ///  Id
        /// </summary>
        public int id { get; set; }

        /// <summary>
        ///  Nome
        /// </summary>
        [Required(ErrorMessage = "O nome é de Preenchimento Obrigatório")]
        [StringLength(50, ErrorMessage = "Nome tem no mínimo 2 caracteres e no máximo 50", MinimumLength = 2)]
        public string nome { get; set; }
        
        /// <summary>
        /// Sobrenome 
        /// /// </summary>
        public string sobrenome { get; set; }

        /// <summary>
        ///  Telefone
        /// </summary>
        public string telefone { get; set; }

        /// <summary>
        ///  Ra
        /// </summary>
        [Required(ErrorMessage = "O RA é de Preenchimento Obrigatório")]
        [Range(1, 9099, ErrorMessage = "O intervalo para cadastro de RA está entre 1 e 9099")]
        public int? ra { get; set; }
    }
}