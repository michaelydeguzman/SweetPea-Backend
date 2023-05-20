using System.ComponentModel.DataAnnotations;

namespace UserService.Data.Entities
{
    public class UserRole
    {
        public int RoleId { get; set; }

        public string? RoleName { get; set; }

        public virtual List<User>? Users {get; set;}
}
}
