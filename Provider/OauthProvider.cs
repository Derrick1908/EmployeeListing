using Microsoft.Owin.Security.OAuth;
using EmployeeListing.Models;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EmployeeListing.Provider
{
    public class OauthProvider: OAuthAuthorizationServerProvider  
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            await Task.Run(() => context.Validated());
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            using (var db = new JobEntities())
            {
                if (db != null)
                {
                    var user = db.USERS.Where(o => o.USERNAME == context.UserName && o.USERPASSWORD == context.Password).FirstOrDefault();
                    if (user != null)
                    {
                        identity.AddClaim(new Claim(ClaimTypes.Role, user.USERROLE));
                        identity.AddClaim(new Claim(ClaimTypes.Name, user.USERNAME));
                        identity.AddClaim(new Claim("LoggedOn", DateTime.Now.ToString()));
                        await Task.Run(() => context.Validated(identity));
                    }
                    else
                    {
                        context.SetError("Wrong Crendtials", "Provided username and password is incorrect");
                    }
                }
                else
                {
                    context.SetError("Wrong Crendtials", "Provided username and password is incorrect");
                }
                return;
            }
        }
    }
}