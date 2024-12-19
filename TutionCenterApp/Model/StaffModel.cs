namespace TutionCenterApp.Model
{
    public class StaffModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Guid DepartmentId { get; set; }
    }

    public class StaffReadModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Guid DepartmentId { get; set; }
    }

    public class StaffQueryModel
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public Guid? DepartmentId { get; set; }
    }
}
