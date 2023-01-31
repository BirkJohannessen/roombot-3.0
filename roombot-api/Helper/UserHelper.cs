public class UserHelper{
    public UserImpl userDB { get ; set; }
    public UserHelper(){
        userDB = new UserImpl();
    }
    public static string fetchUsers(string cookie){
        if(dbImpl.validateAdmin(cookie)){
            return dbImpl.fetchUsers();
        }else{
            return "";
        }
    }
    public static string registerUser(int userID, string cookie){
        if(dbImpl.validateAdmin(cookie)){
            return dbImpl.registerUser();
        }else{
            return "";
        }
    }
    public static string updateUser(int userID, string cookie){
        if(dbImpl.validateAdmin(cookie)||dbImpl.validateUser(userID, cookie)){
            return dbImpl.updateUser(userID, "args");
        }else{
            return "";
        }
    }

    public static string fetchUser(int userID, string cookie){
        //this class should return a userobject with admin status, name and cookie.
        if(dbImpl.validateAdmin(cookie)||dbImpl.validateUser(userID, cookie)){
            return dbImpl.fetchUser(userID);
        }else{
            return "";
        }

    }
}