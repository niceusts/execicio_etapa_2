using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace execicio.Models
{
    public class Vendedor
    {
        [Key]
        [StringLength(12)]
        public string matricula_aluno { get; set; }

        [Display(Name = "Habilitade desde:")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? habilitado_desde { get; set; }

        public int leiloes_criados { get; set; }

        public bool impedido { get; set; }

        [ForeignKey("matricula_aluno")]
        public virtual Aluno aluno { get; set; }
    }
}