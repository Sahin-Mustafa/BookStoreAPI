using BookAPI.Application.Models.Customer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.Application.Validators.Customer
{
    public class CreateCustomer : AbstractValidator<ModelCreateCustomer>
    {
        public CreateCustomer()
        {
            RuleFor(c=>c.Email)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Mail boş geçilemez")
                .MaximumLength(50)
                    .WithMessage("Mail en fazla 50 karakter girilmeli");

            RuleFor(c=>c.Password)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Şifre boş beçilemez")
                .MinimumLength(8)
                    .WithMessage("Şifre en az 8 karakterli olmalı");
        }
    }
}
