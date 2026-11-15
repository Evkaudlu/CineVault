
using Microsoft.Extensions.Hosting;

namespace CineVault.Extensions
{
    public static class HostEnvironmentExtensions
    {
        public static bool IsLocal(this IHostEnvironment env)
        {
            return env.EnvironmentName.Equals(
                "Local",
                StringComparison.OrdinalIgnoreCase);
        }
    }
}
