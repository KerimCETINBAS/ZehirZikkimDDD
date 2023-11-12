using ErrorOr;

namespace ZehirZikkim.Domain.Common.Errors;


public static partial class Errors {

    public static class User {
         public static Error DuplicateEmailException = Error.Conflict(code: "User.DuplicateEmailException", description: "Email already in use.");
    }
}