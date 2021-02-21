using ForestApp_IdentifiyApi_Entity;
using ForestApp_IdentifiyApi_Entity.ParameterModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForestApp_IdentifyApi_Business.Abstract
{
    public interface IUserService
    {
        Task<AuthResponse<object>> Login(UserLoginModel userLoginModel);

        Task<AuthResponse<object>> Register(UserRegisterModel userRegisterModel);

        Task<AuthResponse<object>> ConfirmEmail(string userId, string token);

        Task<AuthResponse<object>> ForgotPassword(string email);

        Task<AuthResponse<object>> UpdateNewPassword(NewPasswordModel newPasswordModel);

    }
}
