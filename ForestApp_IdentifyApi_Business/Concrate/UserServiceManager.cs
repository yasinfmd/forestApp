using ForestApp_IdentifiyApi_Entity;
using ForestApp_IdentifiyApi_Entity.ParameterModels;
using ForestApp_IdentifiyApi_RabbitMq;
using ForestApp_IdentifyApi_Business.Abstract;
using ForestAppBase.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ForestApp_IdentifyApi_Business.Concrate
{
    public class UserServiceManager : IUserService
    {
      


            private readonly UserManager<IdentityUser> _userManager;
        // private readonly IUserManagerRepository<ApplicationUser> _userManagerRepository;
        private readonly AuthResponse<object> _authResponse;
        private static Publisher _publisher;
        //IUserManagerRepository<ApplicationUser> userManagerRepository
        private readonly IConfiguration _configuration;
        public UserServiceManager(IConfiguration configuration, AuthResponse<object> authResponse, Publisher publisher, UserManager<IdentityUser> userManager)
        {
            _configuration = configuration;
            _publisher = publisher;
            _authResponse = authResponse;
            //_userManagerRepository = userManagerRepository;
            _userManager = userManager;
            //_configuration = configuration;
        }
        public Task<AuthResponse<object>> ConfirmEmail(string userId, string token)
        {
            throw new NotImplementedException();
        }

        public Task<AuthResponse<object>> ForgotPassword(string email)
        {
            throw new NotImplementedException();
        }

        public Task<AuthResponse<object>> Login(UserLoginModel userLoginModel)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthResponse<object>> Register(UserRegisterModel userRegisterModel)
        {
            var identityUser = new ApplicationUser { Email = userRegisterModel.Email, UserName = userRegisterModel.Email, PhoneNumber = userRegisterModel.PhoneNumber, Gender = userRegisterModel.Gender, Birthdate = userRegisterModel.BirthDate };
            var result = await _userManager.CreateAsync(identityUser, userRegisterModel.Password);
            if (result.Succeeded)
            {
                var emailConfirm = await _userManager.GenerateEmailConfirmationTokenAsync(identityUser);
                var encodedEmailToken = Encoding.UTF8.GetBytes(emailConfirm);
                var validEmailToken = WebEncoders.Base64UrlEncode(encodedEmailToken);
                string uri = $"{_configuration["Server"]}api/auth/confirmEmail?userId={identityUser.Id}&token={validEmailToken}";
                var jsonData = JsonSerializer.Serialize(new UserEmailModel() { Email = userRegisterModel.Email, Message = $"<h1>Email Adresi Onaylama</h1> <p>Lütfen Email Onaylayın <a href='{uri}'> Tıklayın</a> </p>", Title = "Email Onayı" });
                _publisher.OnPublish("mailQueque", jsonData);
                //_publisher = new Publisher("mailQueque", jsonData);
                _authResponse.Result = "Kullancı Kayıt Olma İşlemi Başarıyla Gerçekleşti";
                _authResponse.isSuccess = true;
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    var errorItem = new ErrorModel(item.Code, item.Description);
                    _authResponse.Errors.Add(errorItem);
                }
                _authResponse.isSuccess = false;
            }
            return _authResponse;
        }

        public Task<AuthResponse<object>> UpdateNewPassword(NewPasswordModel newPasswordModel)
        {
            throw new NotImplementedException();
        }
    }
}
