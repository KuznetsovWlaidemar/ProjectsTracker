namespace ProjectsTracker.Api.Contracts.Problem
{
    public record CreateProblemRequest(
        string TaskName,
        int AuthorId,
        int AssigneeId,
        string Comment,
        int Priority
    );
}
