using System.Collections.Generic;

namespace SoccerManageApp.Models.Admin
{
    public class EditRoleModel
    {
        public EditRoleModel()
        {
            Users=new List<string>();
        }
        public string RoleId { get; set; }
        public string RoleName{get;set;}
        public List<string> Users { get; set; }
    }
}