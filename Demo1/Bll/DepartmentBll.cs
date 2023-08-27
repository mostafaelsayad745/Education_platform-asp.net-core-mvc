using Demo1.Models;

namespace Demo1.Bll
{
    public class DepartmentBll
    {
        DemoDbContext db = new DemoDbContext();
        public List<Department> GetAll()
        {
            return db.Departments.ToList();
        }
        public Department GetById(int id)
        {
            return db.Departments.FirstOrDefault(x => x.Id == id);
        }
        public Department Update(Department department)
        {
            db.Update(department);
            db.SaveChanges();
            return department;
        }
        public void Delete(int id)
        {
            Department dept = db.Departments.FirstOrDefault(students => students.Id == id);
            db.Departments.Remove(dept);
            db.SaveChanges();
        }
        public void Add(Department dept)
        {
            db.Departments.Add(dept);
            db.SaveChanges();
        }
    }
}
