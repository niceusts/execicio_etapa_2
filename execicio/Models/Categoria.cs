using System.ComponentModel.DataAnnotations;

namespace execicio.Models
{
    public class Categoria
    {
        public int id { get; set; }
        
        public string nome { get; set; }
        public string descricao { get; set; }
    }
}
