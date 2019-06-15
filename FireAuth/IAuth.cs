using System;
using System.Threading.Tasks;

namespace FireAuth
{
    public interface IAuth
    {
        Task<string> LoginWithEmailPassword(string email, string password);
    }
}
