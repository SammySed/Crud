using System.ComponentModel.DataAnnotations;

namespace Prod_.Models
{
    public class Fornecedor
    {
        [Key]
        public int FornecedorId { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Nivel { get; set; }      

        public Produto Produto_ { get; set; }
    }
}
