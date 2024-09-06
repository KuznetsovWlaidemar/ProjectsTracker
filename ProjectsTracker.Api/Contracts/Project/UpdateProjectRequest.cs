namespace ProjectsTracker.Api.Contracts.Project
{
    public record UpdateProjectRequest(
        string ProjectName,
        int CustomerCompanyId,
        int ExecutorCompanyId,
        DateTime StartDate,
        DateTime EndDate,
        int Priority
        );
}
