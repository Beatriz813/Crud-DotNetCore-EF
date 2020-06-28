
using Microsoft.AspNetCore.Mvc;
using ApiEF.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ApiEF.Logica;
using ApiEF.Validation;

namespace ApiEF.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class LimpezaController : ControllerBase {

        private readonly LojaContext context;
        public LimpezaController(LojaContext ctx) {
            context = ctx;
        }

        [HttpGet]
        public IActionResult Get() {
            var p = context.TabelaLimpeza.ToList();
            return Ok(p);
        }

        [HttpPost]
        public IActionResult Post(Limpeza limpeza) {
            var Validacao = new LimpezaValidation().Validate(limpeza);
            if (Validacao.IsValid) {
                var produto = context.Add(limpeza);
                context.SaveChanges();
                return Ok("Produto Adicionado");  
            }
            return BadRequest("Erro nos parametros");
        }

        [HttpPut]
        public IActionResult Put(Limpeza limpeza) {
            var produto = context.TabelaLimpeza.SingleOrDefault(ProdutoLimpeza => ProdutoLimpeza.Id == limpeza.Id);
            if (produto != null) {
                LimpezaLogica.PassandoValoresObjeto(produto, limpeza);
                context.SaveChanges();
                return Ok(produto);
            }
            // return Ok($"Produto com id {id} Atualizado");
            return NotFound();
        }

        [HttpDelete]
        public IActionResult Delete(Limpeza limpeza) {
            // var produto = context.TabelaLimpeza.SingleOrDefault(produtoLimpeza => produtoLimpeza.Id == limpeza.Id);
            context.TabelaLimpeza.Remove(limpeza);
            context.SaveChanges();
            return Ok();
        }
    }
}