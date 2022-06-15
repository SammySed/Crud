using System.ComponentModel.DataAnnotations;

namespace Prod_.Models
{
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }

        public string Nome { get; set; }

        public string Modelo { get; set; }

        public string Descricao { get; set; }
        
    }
}
