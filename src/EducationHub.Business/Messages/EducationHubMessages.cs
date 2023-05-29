using ApiResults.CustomAttributes;
using System.ComponentModel;
using System.Net;

namespace EducationHub.Business.Messages
{
    public enum EducationHubMessages
    {
        [StatusCode(HttpStatusCode.OK)]
        [Description("Login realiado com sucesso.")]
        Login_Success,

        [StatusCode(HttpStatusCode.Created)]
        [Description("Usuário criado com sucesso.")]
        SignUp_Success,

        [StatusCode(HttpStatusCode.OK)]
        [Description("Conta confirmada com sucesso.")]
        ConfirmAccount_Success,

        [StatusCode(HttpStatusCode.OK)]
        [Description("Convite enviado com sucesso.")]
        ProfessorInvitation_Success,
    }
}