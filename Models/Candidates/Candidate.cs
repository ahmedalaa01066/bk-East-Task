using EasyTask.Models.Attendances;
using EasyTask.Models.CandidateCourses;
using EasyTask.Models.CandidateKPIs;
using EasyTask.Models.CandidatePermissions;
using EasyTask.Models.CandidateTasks;
using EasyTask.Models.CandidateVacations;
using EasyTask.Models.Departments;
using EasyTask.Models.Enums;
using EasyTask.Models.Jobs;
using EasyTask.Models.Levels;
using EasyTask.Models.Managements;
using EasyTask.Models.Penalities;
using EasyTask.Models.PermissionLogs;
using EasyTask.Models.PermissionRequests;
using EasyTask.Models.PlannedShifts;
using EasyTask.Models.Positions;
using EasyTask.Models.Users;
using EasyTask.Models.VacationRequests;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.Candidates
{
    [Table("Candidate", Schema = "Candidates")]
    public class Candidate : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly JoiningDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? Bio { get; set; }
        public string JobCode { get; set; }
        public CandidateStatus CandidateStatus { get; set; }
        public string Password { get; set; }
        public AttendanceActivation AttendanceActivation { get; set; } = AttendanceActivation.ByFristLogin;

        [Key, ForeignKey("User")]
        public override string ID { get; set; }
        public User User { get; set; }

        [ForeignKey("Manager")]
        public string? ManagerId { get; set; }
        public Candidate Manager { get; set; }

        public ICollection<Candidate> Candidates { get; set; } = new List<Candidate>();
        public ICollection<Penality> Penalities { get; set; } = new List<Penality>();
        public ICollection<CandidateCourse>? candidateCourses { get; set; }
        public ICollection<VacationRequest>? VacationRequests { get; set; }
        public ICollection<PermissionRequest>? PermissionRequests { get; set; }
        public ICollection<CandidateVacation>? CandidateVacations { get; set; }
        public ICollection<CandidatePermission>? CandidatePermissions { get; set; }

        [ForeignKey("Management")]
        public string? ManagementId { get; set; }
        public Management? Management { get; set; }

        [ForeignKey("Department")]
        public string? DepartmentId { get; set; }
        public Department? Department { get; set; }

        [ForeignKey("Level")]
        public string LevelId { get; set; }
        public Level Level { get; set; }

        [ForeignKey("Job")]
        public string? JobId { get; set; }
        public Job? Job { get; set; }

        [ForeignKey("Position")]
        public string PositionId { get; set; }
        public Position Position { get; set; }
        public string? PositionName { get; set; }
        [InverseProperty("Manager")]
        public Management? ManagedManagement { get; set; }
        public ICollection<CandidateKPI> CandidateKPIs { get; set; }
        public ICollection<PlannedShift>? PlannedShifts { get; set; }
        public ICollection<Attendance>? Attendances { get; set; }
        public ICollection<PermissionLog>? PermissionLogs { get; set; }
        public ICollection<CandidateTask>? CandidateTasks { get; set; }
    }
}
