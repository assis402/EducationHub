using EducationHub.Business.Entities;

namespace EducationHub.Business.Interfaces.Services
{
    public interface IEmailService
    {
        public void SendAccountConfirmation(User user, UserActionEmailHistory userActionEmailHistory);

        public void SendProfessorInvitation(string professorEmail, UserActionEmailHistory userActionEmailHistory);
    }
}