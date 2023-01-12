using FluentValidation;

namespace poc_blazor.Shared.DTO
{
    public static class UserDTO
    {
        public class Login
        {
            public string Email { get; set; }
            public string Password { get; set; }

            public class Validator: AbstractValidator<Login>
            {
                public Validator()
                {
                    RuleFor(u => u.Email).EmailAddress().NotEmpty();
                    RuleFor(u => u.Password).NotEmpty().MinimumLength(8);    
                }
            }
        }

        public class Register : Login
        {
            public string UserName { get; set; }
            public string PasswordConfirmation { get; set; }

            public class Validator : AbstractValidator<Register>
            {
                public Validator()
                {
                    RuleFor(u => u.Email).EmailAddress().NotEmpty();
                    RuleFor(u => u.Password).NotEmpty().MinimumLength(8);
                    RuleFor(u => u.PasswordConfirmation).Equal(u => u.Password);
                }
            }
        }
    }
}
