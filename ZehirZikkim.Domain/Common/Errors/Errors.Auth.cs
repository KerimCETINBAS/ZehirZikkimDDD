using ErrorOr;

namespace ZehirZikkim.Domain.Common.Errors;


public static partial class Errors {

    public static class Auth {

        public static Error CredentialsInvalidException => Error.Unauthorized(code: "Auth.InvalidCredentialsException", description: "Credentials invalid");
    }
}