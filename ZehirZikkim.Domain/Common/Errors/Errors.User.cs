using ErrorOr;

namespace ZehirZikkim.Domain.Common.Errors;

public static partial class Errors {

    public static class User {
        public static Error EmailConflictException => Error.Conflict(code: "User.EmailConflictException", description: "Email already exists.");
    }
}