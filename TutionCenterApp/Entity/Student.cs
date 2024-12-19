﻿namespace TutionCenterApp.Entity
{
    public class Student
    {
        public Guid Id{ get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Guid DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
