using Microsoft.AspNetCore.Mvc;
using OpinionAPI.Model;

namespace OpinionAPI.Interface
{
    public interface IUser
    {
        ActionResult login(string username, string password);
        Task<ActionResult> createAccount(string name, string username, string password);
    }
}
