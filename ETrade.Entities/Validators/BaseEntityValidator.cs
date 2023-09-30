using ETrade.Entities.Abstract;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Validators
{
    public class BaseEntityValidator<TEntity>:AbstractValidator<TEntity>
        where TEntity : EntityBase,new()
    {
        public BaseEntityValidator()
        {
            RuleFor(x => x.CreateIPAddress).NotNull().NotEmpty().WithMessage("Zorunlu");
        }
    }
}
