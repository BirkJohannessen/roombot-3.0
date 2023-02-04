using context;
using models;
public class UserImpl{
    public UserImpl(){}

    public bool validateUser(int userID, string cookie, RoombotContext context){
        //TODO
        return true;
    }
    public bool validateAdmin(string cookie, RoombotContext context){
        //TODO
        return true;
    }
    public string fetchUser(int UserID, RoombotContext context){
        //TODO
        return "user";
    }
    public string fetchUsers(RoombotContext context){
        //TODO
        return "users";
    }
    public string updateUser(int UserID, string args, RoombotContext context){
        //TODO
        return "updated user";
    }
    public string deleteUser(int UserID, RoombotContext context){
        //TODO
        return "deleted user";
    }
    public string registerUser(string username, string password, RoombotContext context){
        var user = new User{username="birk", password="test", cookie="213"};
        context.Add<User>(user);
        context.SaveChanges();
        return "?";
    }
}