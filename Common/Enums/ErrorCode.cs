using EasyTask.Helpers;

namespace EasyTask.Common.Enums;

public enum ErrorCode
{
    [DescriptionAnnotation("none", "none")]
    None = 0,
    [DescriptionAnnotation("Validation Errors", "Validation Errors")]
    ValidationErrors = 1,
    [DescriptionAnnotation("خطأ غير معرف", "Unknown Error")]
    UnKnown = 2,
    [DescriptionAnnotation("Not Found ", "Not Found ")]
    NotFound = 3,
    [DescriptionAnnotation("Can not Delete ", "Can not Delete ")]
    CannotDelete = 4,
    [DescriptionAnnotation("Invalid OTP", "Invalid OTP")]
    InvalidOTP = 5,
    [DescriptionAnnotation("Exist Mobile Number", "Exist Mobile Number")]
    ExistMobile = 6,
    [DescriptionAnnotation("Unauthorize Access ", "Unauthorize Access ")]
    Unauthorize = 7,
    [DescriptionAnnotation("can not send Message", "can not send Message")]
    CannotSend = 8,
    [DescriptionAnnotation("Not Active ", "Not Active ")]
    NotActive = 9,
    [DescriptionAnnotation("Can not Edit ", "Can not Edit ")]
    CannotEdit = 10,
    [DescriptionAnnotation("Unauthorize Access Token is blacklisted", "Unauthorize Access  Token is blacklisted")]
    UnauthorizeTokenIsBlackListed,
    [DescriptionAnnotation("Exist E-mail", "Exist E-mail")]
    ExistEmail,
    [DescriptionAnnotation("Management Not Found ", "Management Not Found ")]
    ManagementNotFound,
    [DescriptionAnnotation("Media Not Found ", "Media Not Found ")]
    MediaNotFound,
    [DescriptionAnnotation("Shift Not Found ", "Shift Not Found ")]
    ShiftNotFound,
    [DescriptionAnnotation("Planned Shift Not Found ", "Planned Shift Not Found ")]
    PlannedShiftNotFound,
    [DescriptionAnnotation("Course Not Found ", "Course Not Found ")]
    CourseNotFound,
    [DescriptionAnnotation("candidate not found in tis course", "candidate not found in tis course")]
    CandidateCourseNotFound,
    [DescriptionAnnotation("Exist National Number", "Exist National Number")]
    ExistNationalNumber,
    [DescriptionAnnotation("Mobile Or Password Not Correct", "Mobile Or Password Not Correct")]
    MobileOrPasswordNotCorrect,
    [DescriptionAnnotation("No Account For This Email", "No Account For This Email")]
    NoAccountForEmail,
    [DescriptionAnnotation("User Not Verified ", "User Not Verified ")]
    NotVerified,
    [DescriptionAnnotation("Duplicate Manager", "This manager is already assigned to another management.")]
    DuplicateManager,
    [DescriptionAnnotation("Shift time is out of the provided date range.", "Shift time is out of the provided date range.")]
    ShiftTimeOutOfRange,
    [DescriptionAnnotation("The candidate already assigned to two shifts in the same date ,unassign candidate from old shifts first", "The candidate already assigned to two shifts in the same date ,unassign candidate from old shifts first")]
    OldShiftsExceeded,
    [DescriptionAnnotation("The candidate already assigned to one shift before you must assign now only one shift ,or unassign candidate from old shifts first", "The candidate already assigned to one shift before you must assign now only one shift ,or unassign candidate from old shifts first")]
    OldandNewShiftsExceeded,
    [DescriptionAnnotation("No pause option for this shift", "This shift does not allow pauses, so no pause duration is available")]
    NoPauseOptionForShift,
    [DescriptionAnnotation("Pause time ended", "The candidate has already consumed the allowed pause duration for this shift")]
    PauseTimeEnded,
    [DescriptionAnnotation("No attendance record found for this candidate today.", "No attendance record found for this candidate today.")]
    AttendanceNotFoundForToday,
    [DescriptionAnnotation("No active shift found for this candidate right now.", "No active shift found for this candidate right now.")]
    ShiftNotFoundForRightNow,
    [DescriptionAnnotation("Request must be approved by manager first.", "Request must be approved by manager first.")]
    ManagerApprovalRequired,
    [DescriptionAnnotation("Not enough vacation days available.", "The candidate does not have enough vacation days to deduct.")]
    NotEnoughVacationDays,
    [DescriptionAnnotation("Vacation request dates are invalid.", "The 'FromDate' must be before or equal to 'ToDate'.")]
    InvalidVacationDates,
    [DescriptionAnnotation("You do not have an active shift at the current time ", "You do not have an active shift at the current time")]
    NotHaveShift,
    [DescriptionAnnotation("You cannot start attendance before your shift margin. ", "You cannot start attendance before your shift margin.")]
    WaitForShiftTime,
    [DescriptionAnnotation("You cannot get permission you excceded your available time", "You cannot get permission you excceded your available time")]
    ExccededPermissionTime,

    [DescriptionAnnotation("Can not Cancel Request ", "Can not Cancel Request ")]
    CannotCancel,
    [DescriptionAnnotation("you are late ", "you are late ")]
    Late,
    [DescriptionAnnotation("you do not have permission to leave ", "you do not have permission to leave ")]
    NotHavePermission,


    #region Candidates

    

    #endregion

    #region Projects
    [DescriptionAnnotation("No candidate IDs were provided", "لم يتم إرسال أي مرشحين")] 
    NoCandidateIdsProvided = 1001,
    [DescriptionAnnotation("No available candidates found for this project", "لا يوجد مرشحون متاحون لهذا المشروع")]
    NoAvailableCandidatesForProject = 1002,
    [DescriptionAnnotation("Some candidates cannot be assigned to this project", "بعض المرشحين لا يمكن تعيينهم لهذا المشروع")]
    SomeCandidatesCannotBeAssignedToProject = 1003,


    

    #endregion

}
