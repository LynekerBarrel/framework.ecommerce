using Microsoft.AspNetCore.Identity;

namespace framework.ecommerce.api.auth.Extensions
{
    /// <summary>
    /// IdentityMensagensPortugues
    /// </summary>
    public class IdentityMensagensPortugues : IdentityErrorDescriber
    {
        /// <summary>
        /// DefaultError
        /// </summary>
        /// <returns></returns>
        public override IdentityError DefaultError() { return new IdentityError { Code = nameof(DefaultError), Description = $"Ocorreu um erro desconhecido." }; }
        /// <summary>
        /// ConcurrencyFailure
        /// </summary>
        /// <returns></returns>
        public override IdentityError ConcurrencyFailure() { return new IdentityError { Code = nameof(ConcurrencyFailure), Description = "Falha de concorrência otimista, o objeto foi modificado." }; }
        /// <summary>
        /// PasswordMismatch
        /// </summary>
        /// <returns></returns>
        public override IdentityError PasswordMismatch() { return new IdentityError { Code = nameof(PasswordMismatch), Description = "Senha incorreta." }; }
        /// <summary>
        /// InvalidToken
        /// </summary>
        /// <returns></returns>
        public override IdentityError InvalidToken() { return new IdentityError { Code = nameof(InvalidToken), Description = "Token inválido." }; }
        /// <summary>
        /// LoginAlreadyAssociated
        /// </summary>
        /// <returns></returns>
        public override IdentityError LoginAlreadyAssociated() { return new IdentityError { Code = nameof(LoginAlreadyAssociated), Description = "Já existe um usuário com este login." }; }
        /// <summary>
        /// InvalidUserName
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public override IdentityError InvalidUserName(string userName) { return new IdentityError { Code = nameof(InvalidUserName), Description = $"O login '{userName}' é inválido, pode conter apenas letras ou dígitos." }; }
        /// <summary>
        /// InvalidEmail
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public override IdentityError InvalidEmail(string email) { return new IdentityError { Code = nameof(InvalidEmail), Description = $"O email '{email}' é inválido." }; }
        /// <summary>
        /// DuplicateUserName
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public override IdentityError DuplicateUserName(string userName) { return new IdentityError { Code = nameof(DuplicateUserName), Description = $"O login '{userName}' já está sendo utilizado." }; }
        /// <summary>
        /// DuplicateEmail
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public override IdentityError DuplicateEmail(string email) { return new IdentityError { Code = nameof(DuplicateEmail), Description = $"O email '{email}' já está sendo utilizado." }; }
        /// <summary>
        /// InvalidRoleName
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public override IdentityError InvalidRoleName(string role) { return new IdentityError { Code = nameof(InvalidRoleName), Description = $"A permissão '{role}' é inválida." }; }
        /// <summary>
        /// DuplicateRoleName
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public override IdentityError DuplicateRoleName(string role) { return new IdentityError { Code = nameof(DuplicateRoleName), Description = $"A permissão '{role}' já está sendo utilizada." }; }
        /// <summary>
        /// UserAlreadyHasPassword
        /// </summary>
        /// <returns></returns>
        public override IdentityError UserAlreadyHasPassword() { return new IdentityError { Code = nameof(UserAlreadyHasPassword), Description = "O usuário já possui uma senha definida." }; }
        /// <summary>
        /// UserLockoutNotEnabled
        /// </summary>
        /// <returns></returns>
        public override IdentityError UserLockoutNotEnabled() { return new IdentityError { Code = nameof(UserLockoutNotEnabled), Description = "O lockout não está habilitado para este usuário." }; }
        /// <summary>
        /// UserAlreadyInRole
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public override IdentityError UserAlreadyInRole(string role) { return new IdentityError { Code = nameof(UserAlreadyInRole), Description = $"O usuário já possui a permissão '{role}'." }; }
        /// <summary>
        /// UserNotInRole
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public override IdentityError UserNotInRole(string role) { return new IdentityError { Code = nameof(UserNotInRole), Description = $"O usuário não tem a permissão '{role}'." }; }
        /// <summary>
        /// PasswordTooShort
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public override IdentityError PasswordTooShort(int length) { return new IdentityError { Code = nameof(PasswordTooShort), Description = $"As senhas devem conter ao menos {length} caracteres." }; }
        /// <summary>
        /// PasswordRequiresNonAlphanumeric
        /// </summary>
        /// <returns></returns>
        public override IdentityError PasswordRequiresNonAlphanumeric() { return new IdentityError { Code = nameof(PasswordRequiresNonAlphanumeric), Description = "As senhas devem conter ao menos um caracter não alfanumérico." }; }
        /// <summary>
        /// PasswordRequiresDigit
        /// </summary>
        /// <returns></returns>
        public override IdentityError PasswordRequiresDigit() { return new IdentityError { Code = nameof(PasswordRequiresDigit), Description = "As senhas devem conter ao menos um digito ('0'-'9')." }; }
        /// <summary>
        /// PasswordRequiresLower
        /// </summary>
        /// <returns></returns>
        public override IdentityError PasswordRequiresLower() { return new IdentityError { Code = nameof(PasswordRequiresLower), Description = "As senhas devem conter ao menos um caracter em caixa baixa ('a'-'z')." }; }
        /// <summary>
        /// PasswordRequiresUpper
        /// </summary>
        /// <returns></returns>
        public override IdentityError PasswordRequiresUpper() { return new IdentityError { Code = nameof(PasswordRequiresUpper), Description = "As senhas devem conter ao menos um caracter em caixa alta ('A'-'Z')." }; }
    }
}