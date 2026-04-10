namespace EasyTask.Features.Projects.GetAllProjectCandidates
{
    public class GetAllProjectCandidatesResponseVm
    {
        public string Id { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? DepartmentID { get; set; }
        public string DepartmentName { get; set; } = null!; 
        public string? ManagementID { get; set; }
        public string ManagementName { get; set; } = null!;
    }
}
