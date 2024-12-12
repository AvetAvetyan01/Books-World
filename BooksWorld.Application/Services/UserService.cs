//using Microsoft.AspNetCore.Identity;

//namespace BooksWorld.Application.Services;

//public class UserService : IUserService
//{
//    private readonly SignInManager<User> _signInManager;

//    public UserService(
//        SignInManager<User> signInManager
//    ){
//        _signInManager = signInManager;
//    }

//    public User Get(UserLogin loginModel)
//    {
//        var user = _signInManager.UserManager.FindByEmailAsync(loginModel.Email).Result;

//        if (user is null) return null!;

//        bool canSignIn = _signInManager.UserManager.CheckPasswordAsync(user, loginModel.Password).Result;

//        return canSignIn ? user : null!;
//    }
//}