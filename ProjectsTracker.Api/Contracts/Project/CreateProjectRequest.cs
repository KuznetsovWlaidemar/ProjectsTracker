namespace ProjectsTracker.Api.Contracts.Project
{
    public record CreateProjectRequest(
        string ProjectName,
        int CustomerCompanyId,
        int ExecutorCompanyId,
        DateTime StartDate,
        DateTime EndDate,
        int Priority
    );
}
