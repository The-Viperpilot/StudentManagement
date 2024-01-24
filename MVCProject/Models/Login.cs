using System.ComponentModel.DataAnnotations;

namespace MVCProject.Models
{
    public class Login
    {
        [Key]
        public string UserName { get; set; }
        public string Pwd{ get; set; }    

    }
}
