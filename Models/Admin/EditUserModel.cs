using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace SoccerManageApp.Models.Admin
{
    public class EditUserModel
    {
        // public EditUserModel()
        // {
        //     Roles=new List<string>();
        // }
        public string UserId { get; set; }
        [Required]
        public string Username { get;set;}
        [Required]
        public string Email { get; set; }
        public IList<string> Roles{get;set;}
    }
}