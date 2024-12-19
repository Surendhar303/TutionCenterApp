namespace TutionCenterApp.Entity
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Student> Students { get; set; }
        public ICollection<Staff> Staffs { get; set; }
    }
}
