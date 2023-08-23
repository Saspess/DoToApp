namespace ToDoApp.Business.DTOs.AppUser
{
    public class AppUserRegisterDto
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string ConfirmedPassword { get; set; } = null!;
    }
}
