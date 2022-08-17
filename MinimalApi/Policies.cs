using Microsoft.AspNetCore.Authorization;

namespace MinimalApi
{
    public static class Policies
    {
        public const string CanHaveAdmin = "CanHaveAdmin";
        public const string CanHaveModerator = "CanHaveModerator";
        public static AuthorizationPolicy CanHaveAdminPolicy()
        {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireClaim("role", "admin")
                .Build();
        }

        public static AuthorizationPolicy CanHaveModeratorPolicy()
        {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireClaim("role", new List<string>
                {
                    "admin",
                    "mod"
                })
                .Build();
        }
    }
}
