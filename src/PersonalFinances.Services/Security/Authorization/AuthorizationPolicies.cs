using Microsoft.AspNetCore.Authorization;

namespace PersonalFinances.Services.Security.Authorization
{
    public static class AuthorizationPolicies
    {
        public static AuthorizationPolicy HasWriteActionPolicy { get; } = new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .RequireClaim("scope", "write")
            .Build();
    }
}
