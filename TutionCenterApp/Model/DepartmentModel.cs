namespace TutionCenterApp.Model
{
    public class DepartmentModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class DepartmentReadModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class DepartmentQueryModel
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
    }
}
