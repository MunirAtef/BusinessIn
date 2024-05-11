using Microsoft.Extensions.Configuration;

namespace BusinessIn.Application.Secrets;

public static class Secrets {
    public static string ConnectionString { get; private set; } = null!;

    public static void SetSecrets(IConfiguration configuration) {
        ConnectionString = configuration.GetConnectionString("DefaultSQLConnection") ?? "";
    }
}