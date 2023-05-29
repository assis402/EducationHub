namespace EducationHub.Business.Entities
{
    public class Course : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string ProfessorId { get; set; }

        public int WorkLoad { get; set; }

        public int TotalRegistrations { get; set; }

        //AVALIACAO
        //COMENTARIOS
    }
}