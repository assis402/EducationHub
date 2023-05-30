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
        
        [StatusCode(HttpStatusCode.Created)]
        [Description("Curso criado com sucesso.")]
        CourseInsert_Success,  
        
        [StatusCode(HttpStatusCode.Created)]
        [Description("Vídeo inserido com sucesso.")]
        VideoInsert_Success,  
        
        [StatusCode(HttpStatusCode.Created)]
        [Description("Questão criada com sucesso.")]
        QuestionInsert_Success,

        [StatusCode(HttpStatusCode.OK)]
        [Description("Curso atualizado com sucesso.")]
        CourseUpdate_Success,

        [StatusCode(HttpStatusCode.OK)]
        [Description("Vídeo atualizado com sucesso.")]
        VideoUpdate_Success,

        [StatusCode(HttpStatusCode.OK)]
        [Description("Questão atualizada com sucesso.")]
        QuestionUpdate_Success,

        [StatusCode(HttpStatusCode.OK)]
        [Description("Curso deletado com sucesso.")]
        CourseDelete_Success,

        [StatusCode(HttpStatusCode.OK)]
        [Description("Vídeo deletado com sucesso.")]
        VideoDelete_Success,

        [StatusCode(HttpStatusCode.OK)]
        [Description("Questão deletada com sucesso.")]
        QuestionDelete_Success,
    }
}