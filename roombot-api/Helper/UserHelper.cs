using context;
public class UserHelper{
    public UserImpl userDB { get ; set; }
    public UserHelper(){
        userDB = new UserImpl();
    }
    public string fetchUsers(string cookie, RoombotContext context){
        if(userDB.validateAdmin(cookie, context)){
            return userDB.fetchUsers(context);
        }else{
            return "";
        }
    }
    public string registerUser(string username, string password, string cookie, RoombotContext context){
        if(userDB.validateAdmin(cookie, context)){
            //TODO: validate input data
            //TODO: check that user doesnt already exist
            return userDB.registerUser(username, password, context);
        }else{
            return "";
        }
    }
    public string updateUser(int userID, string cookie, RoombotContext context){
        if(userDB.validateAdmin(cookie, context) || userDB.validateUser(userID, cookie, context)){
            return userDB.updateUser(userID, "args", context);
        }else{
            return "";
        }
    }

    public string fetchUser(int userID, string cookie, RoombotContext context){
        //this class should return a userobject with admin status, name and cookie.
        if(userDB.validateAdmin(cookie, context) || userDB.validateUser(userID, cookie, context)){
            return userDB.fetchUser(userID, context);
        }else{
            return "";
        }

    }
}