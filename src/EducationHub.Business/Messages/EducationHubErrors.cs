using System.ComponentModel;

namespace EducationHub.Business.Messages
{
    public enum EducationHubErrors
    {
        [Description("Os dados fornecidos estão incorretos.")]
        Login_Error_Unauthenticated,

        [Description("Ocorreu um erro interno na aplicação, por favor, tente novamente.")]
        Application_Error_General,
    }
}
