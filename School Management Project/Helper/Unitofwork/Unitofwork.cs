using Microsoft.EntityFrameworkCore;
using School_Management_Project.Models;
using School_Management_Project.Repository;
using System.Numerics;

namespace School_Management_Project.Helper.Unitofwork
{
    public class Unitofwork : Iunitofwork
    {
        private readonly DbschoolContext _context;
        public IstudentRepository student { get; private set; }

        public ITeacherRepository teacher { get; private set; }
        public ISubjectRepository subject { get; private set; }
        public Unitofwork(DbschoolContext context)
        {
            _context = context;
            student =new StudentRepository(context);
            teacher = new TeacherRepository(context);
            subject = new SubjectRepository(context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
