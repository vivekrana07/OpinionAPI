using System.ComponentModel.DataAnnotations;

namespace OpinionAPI.Context
{
    public class LoginContext
    {
        public string? Name { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
