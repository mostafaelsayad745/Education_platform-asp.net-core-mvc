using Demo1.Models;

namespace Demo1.Bll
{
    public class StudentBll
    {
        DemoDbContext db = new DemoDbContext();
        public List<Student> GetAll()
        {
            return db.Students.ToList();
        }
        public Student GetById(int id)
        {
            return db.Students.FirstOrDefault(x => x.Id == id);
        }
        public Student Update(Student student)
        {
            db.Update(student);
            db.SaveChanges();
            return student;
        }
        public void Delete(int id)
        {
            Student std = db.Students.FirstOrDefault(students => students.Id == id);
            db.Students.Remove(std);
            db.SaveChanges();
        }
        public void Add(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }
    }
}
