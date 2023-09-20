using System;
using System.ComponentModel.DataAnnotations;

namespace execicio.Models
{
    public class Aluno
    {

        [Key]
        [MaxLength(12)]
        public string matricula { get; set; }

        [Required]
        [MaxLength(100)]
        public string nome { get; set; }
        public DateTime? data_nascimemento { get; set; }

        [MaxLength(50)]
        public string email { get; set; }

        [MaxLength(20)]
        public string tipo_logradouro { get; set; }

        [MaxLength(100)]
        public string nome_logradouro { get; set; }

        [MaxLength(10)]
        public string numero { get; set; }

        [MaxLength(50)]
        public string bairro { get; set; }

        [MaxLength(50)]
        public string cidade { get; set; }

        [MaxLength(2)]
        public string uf { get; set; }

        [MaxLength(8)]
        public string cep { get; set; }

        [MaxLength(12)]
        public string telefone { get; set; }

        [MaxLength(11)]
        public string cpf { get; set; }
    }
}
