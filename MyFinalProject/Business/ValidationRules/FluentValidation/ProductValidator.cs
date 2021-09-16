using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        //ctor yaz tabtab yap
        public ProductValidator()
        {
            //FluentValidation eklentisi eklenir NugetManagerdan
            RuleFor(p => p.ProductName).NotEmpty();//Boş olamaz
            RuleFor(p => p.ProductName).MinimumLength(2);//En az 2 karakter olmalı
            RuleFor(p => p.UnitPrice).NotEmpty();//Boş olamaz
            RuleFor(p => p.UnitPrice).GreaterThan(0);//Fiyat 0'dan büyük olmalı
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);//CategoriyId =1 olan girişlerde ücret en düşük 10 olmalıdır.
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürün ismi 'A'harfi ile başlamalıdır");//Ürün ismi A harfi ile başlar
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
