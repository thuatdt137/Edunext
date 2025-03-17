namespace Edunext.Service
{
    public interface IClassEnrollmentService
    {
        bool validateClassEnrollment(int id, string name);
        string SaveClassEnrollment(int id, int name);
    }
}
