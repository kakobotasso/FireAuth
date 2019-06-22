using System;
using System.Threading.Tasks;
using FireAuth;
using FireAuth.iOS;
using Xamarin.Forms;
using Firebase.Auth;

[assembly: Dependency(typeof(AuthIOS))]
namespace FireAuth.iOS
{
    public class AuthIOS : IAuth
    {
        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            try
            {
                var user = await Auth.DefaultInstance.SignInWithPasswordAsync(email, password);
                return await user.User.GetIdTokenAsync();
            }
            catch (Exception e)
            {
                return "";
            }

        }

        public bool SignUpWithEmailPassword(string email, string password)
        {
            try
            {
                var signUpTask = Auth.DefaultInstance.CreateUserAsync(email, password);
                return signUpTask.Result != null;
            }
            catch (Exception e)
            {
                return false;
            } 

        }
    }
}
