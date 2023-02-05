using context;
using models;
public class UserImpl{
    private readonly RoombotContext _context;
    public UserImpl(RoombotContext context){
        _context=context;
    }

    public bool validateUser(int userID, string cookie){
        //TODO
        return true;
    }
    public bool validateAdmin(string cookie){
        //TODO
        return true;
    }
    public User fetchUser(int userID){
        return _context.tbl_users.Single( user => user.id==userID );
    }
    public List<User> fetchUsers(){
        var users = _context.tbl_users.ToList();
        return users;
    }
    public string updateUser(int UserID, string args){
        //TODO
        return "updated user";
    }
    public string deleteUser(int UserID){
        //TODO
        return "deleted user";
    }
    public void registerUser(string username, string password){
        //TODO hash password
        //generate cookie?
        User user = new User{username=username, password=password, cookie="", admin=false};
        _context.Add<User>(user);
        _context.SaveChanges();
    }
}