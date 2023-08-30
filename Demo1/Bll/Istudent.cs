using Demo1.Models;

namespace Demo1.Bll
{
    public interface Istudent
    {
        public List<Student> GetAll();

        public Student GetById(int id) ;

        public Student Update(Student std);
        public Student Add(Student student);
        public void Delete(int id);
    }
}
