namespace TutionCenterApp.Model
{
    public class StudentModel 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Guid DepartmentId { get; set; }
    }

    public class StudentReadModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Guid DepartmentId { get; set; }
    }

    public class StudentQueryModel
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public Guid? DepartmentId { get; set; }
    }
}
