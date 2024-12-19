namespace DiTest
{
    public interface IStudentService
    {
        int Get();

    }
    public class StudentService : IStudentService
    {
        private int _id = 0;
        public int Get()
        {
            _id += 1;
            return _id;
        }

    }
}
