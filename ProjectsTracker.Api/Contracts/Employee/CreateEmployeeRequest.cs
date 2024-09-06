namespace ProjectsTracker.Api.Contracts.Employee
{
    public record CreateEmployeeRequest(
        string FirstName,
        string LastName,
        string MiddleName,
        string Email
    );
}
