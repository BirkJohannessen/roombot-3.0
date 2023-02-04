public class UserHelper{
    public UserImpl userDB { get ; set; }
    public UserHelper(){
        userDB = new UserImpl();
    }
    public string fetchUsers(string cookie){
        if(userDB.validateAdmin(cookie)){
            return userDB.fetchUsers();
        }else{
            return "";
        }
    }
    public string registerUser(string username, string password, string cookie){
        if(userDB.validateAdmin(cookie)){
            return userDB.registerUser(username, password);
        }else{
            return "";
        }
    }
    public string updateUser(int userID, string cookie){
        if(userDB.validateAdmin(cookie) || userDB.validateUser(userID, cookie)){
            return userDB.updateUser(userID, "args");
        }else{
            return "";
        }
    }

    public string fetchUser(int userID, string cookie){
        //this class should return a userobject with admin status, name and cookie.
        if(userDB.validateAdmin(cookie) || userDB.validateUser(userID, cookie)){
            return userDB.fetchUser(userID);
        }else{
            return "";
        }

    }
}