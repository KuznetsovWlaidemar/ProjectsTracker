namespace ProjectsTracker.Api.Contracts.Employee
{
    public record UpdateEmployeeRequest(
        string FirstName,
        string LastName,
        string MiddleName,
        string Email
    );
}
