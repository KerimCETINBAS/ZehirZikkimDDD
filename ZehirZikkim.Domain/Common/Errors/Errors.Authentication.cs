using ErrorOr;

namespace ZehirZikkim.Domain.Common.Errors;


public static partial class Errors {
    public static class Authentication {
        public static Error InvalidCredentials => Error.Unauthorized(
            code: "Authentication.InvalidCredentials",
            description: "Given credentials invalid"
        );
    }
}