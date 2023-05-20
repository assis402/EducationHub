using ApiResults.CustomAttributes;
using System.ComponentModel;
using System.Net;

namespace EducationHub.Business.Messages
{
    public enum EducationHubErrors
    {
        [StatusCode(HttpStatusCode.BadRequest)]
        [Description("A requisição está inválida.")]
        Application_Error_InvalidRequest,

        [StatusCode(HttpStatusCode.NotFound)]
        [Description("Os dados fornecidos estão incorretos.")]
        Login_Error_WrongEmailOrPassword,

        [Description("'Email' está inválido.")]
        Login_Validation_InvalidEmail,

        [StatusCode(HttpStatusCode.BadRequest)]
        [Description("Ocorreu um erro interno na aplicação, por favor, tente novamente.")]
        Application_Error_General,

        [StatusCode(HttpStatusCode.BadRequest)]
        [Description("Já existe um usuário com o mesmo Username ou mesmo Email.")]
        SignUp_Error_UserAlreadyExists,
    }
}