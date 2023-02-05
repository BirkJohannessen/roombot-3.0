using context;
using models;
using response;
public class UserHelper{
    public UserImpl userDB { get ; set; }
    public RoombotResponse _response { get; set; }
    public UserHelper(RoombotContext context, RoombotResponse response){
        userDB = new UserImpl(context);
        _response = response;
    }
    public RoombotResponse fetchUsers(string cookie){
        if(userDB.validateAdmin(cookie)){
            List<User> users = userDB.fetchUsers();
            _response.data = users;
            _response.status = Status.Success;
        }else{
            _response.status = Status.Failed;
            _response.error = "you are not admin";
        }
        return _response;
    }
    public RoombotResponse registerUser(string username, string password, string cookie){
        if(userDB.validateAdmin(cookie)){
            //TODO: validate input data
            //TODO: check that user doesnt already exist
            userDB.registerUser(username, password);
            _response.status = Status.Success;
        }else{
            _response.status = Status.Failed;
            _response.error = "you are not admin";
        }
        return _response;
    }
    public RoombotResponse updateUser(int userID, string cookie){
        if(userDB.validateAdmin(cookie) || userDB.validateUser(userID, cookie)){
            _response.data = userDB.updateUser(userID, "args");
            _response.status = Status.Success;
        }else{
            _response.status = Status.Failed;
            _response.error = "you are not autorized to that action";
        }
        return _response;
    }

    public RoombotResponse fetchUser(int userID, string cookie){
        //this class should return a userobject with admin status, name and cookie.
        if(userDB.validateAdmin(cookie) || userDB.validateUser(userID, cookie)){
            _response.data = userDB.fetchUser(userID);
            _response.status = Status.Success;
        }else{
            _response.status = Status.Failed;
            _response.error = "you are not autorized to that action";
        }
        return _response;
    }
    public RoombotResponse deleteUser(int userID, string cookie){
        if(userDB.validateAdmin(cookie)){
             _response.data = userDB.deleteUser(userID);
            _response.status = Status.Success;
        }else{
            _response.status = Status.Failed;
            _response.error = "you are not admin";
        }
        return _response;
    }
}