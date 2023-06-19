using api_projeto_final.DataModels;
using api_projeto_final.Service;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace api_projeto_final
{
    public class TokenValidationHandler : AuthorizationHandler<AuthReq>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AuthReq requirement)
        {

            if (IsValidToken(context.User.Claims))
            {
                authService auth = new authService();

                Claim guivenToken = context.User.Claims.First(claim => claim.Type == "token");
                token? token = auth.validateSessionToken(guivenToken.Value);
                if (token != null)
                    context.Succeed(requirement);
                else
                {
                    context.Fail();
                }
            }else
                context.Fail();

            return Task.CompletedTask;
        }

        // esse codigo ta uma merda
        private bool IsValidToken(IEnumerable<Claim> claims)
        {

            return claims.Any(claim => claim.Type == "token");
        }
    }

    // Custom requirement class to associate with the policy
    public class AuthReq : IAuthorizationRequirement { }
}
