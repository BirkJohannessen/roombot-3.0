using context;
using models;
public class UserImpl{
    private readonly RoombotContext _context;
    public UserImpl(RoombotContext context){
        _context=context;
    }

    public bool validateUser(int userID, string cookie){
        User user = _context.tbl_users.Single( user => user.cookie == cookie );
        if( user.id == userID ){
            return true;
        }
        return false;
    }
    public bool userExists(string cookie){
        try{
            _context.tbl_users.Single( user => user.cookie == cookie );
            return true;
        }catch(InvalidOperationException){
            return false;
        }
    }
    public bool validateAdmin(string cookie){
        /*
        User user = _context.tbl_users.Single( user => user.cookie == cookie );
        if( user.admin ){
            return true;
        }
        return false;
        */
        return true;

    }
    public User fetchUserByCookie(string cookie){
            return _context.tbl_users.Single( user => user.cookie == cookie);
    }
    public User fetchUser(int userID){
        return _context.tbl_users.Single( user => user.id==userID );
    }
    public List<User> fetchUsers(){
        var users = _context.tbl_users.ToList();
        return users;
    }
    public void deleteUser(int userID){
        //TODO: Delete all reservations of user
        _context.Remove<User>(fetchUser(userID));
        _context.SaveChanges();
    }
    public void registerUser(string username, string password){
        //TODO hash password
        //generate cookie?
        User user = new User{username=username, password=password, cookie="cookie", admin=true};
        _context.Add<User>(user);
        _context.SaveChanges();
    }
    public bool validateLogin(string username, string password){
        //TODO: hash password string
        //TODO: check that User exist
        string passwordHash = password;
        User user = _context.tbl_users.Single( user => user.username == username );
        if(password == user.password){
            return true;
        }
        return false;
    }
    public string updateUser(int UserID, string args){
        //TODO
        return "this action is not impelmented.";
    }
}