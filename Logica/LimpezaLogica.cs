using ApiEF.Models;

namespace ApiEF.Logica {
    public class LimpezaLogica {
        public static void PassandoValoresObjeto(Limpeza obj1, Limpeza obj2) {
            obj1.Nome = obj2.Nome;
            obj1.Preco = obj2.Preco;
        }
    }
}
