namespace Edunext.Repository
{
    public interface IClassEnrollmentRepository
    {
        bool validateClassEnrollment(int id, string name);
        string SaveClassEnrollment(int id, int name);
    }
}
