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

        [Description("'Role' está inválido.")]
        SignUp_Validation_InvalidRole,

        [Description("Não foi possível realizar o login.")]
        User_Validation_Fail,

        [Description("Sua conta ainda não está confirmada. Confira sua caixa de e-mail.")]
        User_Validation_UncomfirmedAccount,

        [Description("Seu usuário se encontra bloqueado.")]
        User_Validation_Blocked,

        [StatusCode(HttpStatusCode.InternalServerError)]
        [Description("Ocorreu um erro interno na aplicação, por favor, tente novamente.")]
        Application_Error_General,

        [StatusCode(HttpStatusCode.BadRequest)]
        [Description("Já existe um usuário com o mesmo Username ou mesmo Email.")]
        SignUp_Error_UserAlreadyExists,

        [StatusCode(HttpStatusCode.BadRequest)]
        [Description("'Token' não pode ser nulo.")]
        SignUp_Error_TokenIsNull,

        [StatusCode(HttpStatusCode.NotFound)]
        [Description("Esta ação não foi iniciada ou já se encontra completada.")]
        Action_Error_NotFound,

        [StatusCode(HttpStatusCode.NotFound)]
        [Description("Registro não encontrado.")]
        Error_NotFound,

        [StatusCode(HttpStatusCode.BadRequest)]
        [Description("Já um curso com o mesmo títilo.")]
        CourseInsert_Error_AlreadyExists,

        [StatusCode(HttpStatusCode.BadRequest)]
        [Description("Já um curso com o mesmo títilo.")]
        CourseUpdate_Error_AlreadyExists,

        [StatusCode(HttpStatusCode.Forbidden)]
        [Description("Usuário não possui permissão para alterar este curso.")]
        CourseUpdate_Error_Forbidden,

        [StatusCode(HttpStatusCode.Forbidden)]
        [Description("'Status' está invalido.")]
        CourseUpdate_Validation_InvalidStatus,

        [StatusCode(HttpStatusCode.Forbidden)]
        [Description("Usuário não possui permissão para deletar este curso.")]
        CourseDelete_Error_Forbidden,

        [StatusCode(HttpStatusCode.BadRequest)]
        [Description("É necessário enviar 4 alternativas.")]
        Question_Error_Validation,
    }
}