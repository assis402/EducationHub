using System.ComponentModel;

namespace EducationHub.Business.Messages
{
    public enum EducationHubErrors
    {
        [Description("A requisição está inválida.")]
        Application_Error_InvalidRequest,

        [Description("Os dados fornecidos estão incorretos.")]
        Login_Error_WrongEmailOrPassword,

        [Description("'Email' está inválido.")]
        Login_Validation_InvalidEmail,

        [Description("Ocorreu um erro interno na aplicação, por favor, tente novamente.")]
        Application_Error_General,

        [Description("Já existe um usuário com o mesmo Username ou mesmo Email.")]
        SignUp_Error_UserAlreadyExists,
    }
}
