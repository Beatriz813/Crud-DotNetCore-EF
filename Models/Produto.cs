using System.Collections.Generic;

namespace ApiEF.Models {
    public class Produto {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Limpeza> Limpezas { get; set; }
    }
}
