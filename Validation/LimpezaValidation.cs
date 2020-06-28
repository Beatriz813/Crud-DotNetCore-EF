using ApiEF.Models;
using FluentValidation;

namespace ApiEF.Validation {
    public class LimpezaValidation : AbstractValidator<Limpeza> {
        public LimpezaValidation () {
            RuleFor(produto => produto.Nome).NotEmpty();
            RuleFor(produto => produto.Preco).NotEmpty();
        }
    }
}