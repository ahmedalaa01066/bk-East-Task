using EasyTask.Models.Enums;

namespace EasyTask.Common.Endpoints;

public class UserState
{
    public string UserID { set; get; } = string.Empty;
    public string Username { get; set; } = "System";
    public Role RoleID { get; set; } 
}

