using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace execicio.Models
{
    public class Produto
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(40)]
        public string nome { get; set; }

        [Required]
        [StringLength(500)]
        public string descricao { get; set; }

        [Required]
        [ForeignKey("categoria")]
        public int id_categoria { get; set; }

        [Required]
        [StringLength(200)]
        public string foto { get; set; }

        [Required]
        [StringLength(12)]
        [ForeignKey("matricula_vendedor")]
        public string matricula_vendedor { get; set; }

        [Required]
        public DateTime data_cadastro { get; set; }

        // Propriedade de navegação para a categoria
        public virtual Categoria categoria { get; set; }

        // Propriedade de navegação para o vendedor
        public virtual Vendedor vendedor { get; set; }
    }
}

