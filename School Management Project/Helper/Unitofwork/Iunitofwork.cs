using School_Management_Project.Repository;

namespace School_Management_Project.Helper.Unitofwork
{
    public interface Iunitofwork
    {
        IstudentRepository student { get; }
        ITeacherRepository teacher { get; }
        ISubjectRepository subject { get; }
        void Save();
    }
}
