using FluentValidation;
using ForestApp_IdentifiyApi_Entity.ParameterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForestApp_IdentifiyApi.Validators
{
    public class RegisterValidator:AbstractValidator<UserRegisterModel>
    {
        public RegisterValidator()
        {
            CustomRegisterAgeValidation customRegisterAgeValidation = new CustomRegisterAgeValidation();
            RuleFor(rm => rm.Email).EmailAddress()
                .WithMessage("Email Adresi Geçersiz")
                .NotNull().
                WithMessage("Email Adresi Boş Olamaz").
                NotEmpty().
                WithMessage("Email Adresi Boş Olamaz");
            RuleFor(x => x.Password).NotEmpty().
                WithMessage("Parola Boş Olamaz").
                MinimumLength(8).
                WithMessage("Minimumu 8 Karakter Olmalıdır");

            RuleFor(x => x.Gender).NotEmpty().
                WithMessage("Cinsiyet Boş Olamaz").
                NotNull().
                WithMessage("Cinsiyet Boş Olamaz");

            RuleFor(x => x.BirthDate).NotNull().
                WithMessage("Doğum Tarihi Boş Olamaz").
                NotEmpty().
                WithMessage("Doğum Tarihi Boş Olamaz").
                Must(customRegisterAgeValidation.ValidAge).
                WithMessage("Yaşınız 15 den küçük olamaz");

            RuleFor(x => x.PhoneNumber).NotNull().
                WithMessage("Telefon Numarası Boş Olamaz").
                MinimumLength(11).
                WithMessage("Telefon Numarası 11 Karakterden Küçük Olamaz").
                NotEmpty().
                WithMessage("Telefon Numarası Boş Olamaz");
        }
    }
}
