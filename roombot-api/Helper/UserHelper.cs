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
        //TODO validate input
        if (!userDB.userExists(cookie)) {
            _response.status = Status.Failed;
            _response.error = "session expired";
            return _response;
        }
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
        if (!userDB.userExists(cookie)) {
            _response.status = Status.Failed;
            _response.error = "session expired";
            return _response;
        }
        //TODO validate input
        if(userDB.validateAdmin(cookie)){
            //TODO: check that user doesnt already exist
            userDB.registerUser(username, password);
            _response.status = Status.Success;
        }else{
            _response.status = Status.Failed;
            _response.error = "you are not admin";
        }
        return _response;
    }

    public RoombotResponse fetchUser(int userID, string cookie){
        if (!userDB.userExists(cookie)) {
            _response.status = Status.Failed;
            _response.error = "session expired";
            return _response;
        }
        //TODO validate input
        if(userDB.validateAdmin(cookie) || userDB.validateUser(userID, cookie)){
            //TODO: Check that user exists.
            try{
                _response.data = userDB.fetchUser(userID);
                _response.status = Status.Success;
            }catch(Exception){
                _response.status = Status.Failed;
                _response.error = "user does not exist.";
            }
        }else{
            _response.status = Status.Failed;
            _response.error = "you are not autorized to that action";
        }
        return _response;
    }
    public RoombotResponse deleteUser(int userID, string cookie){
        if (!userDB.userExists(cookie)) {
            _response.status = Status.Failed;
            _response.error = "session expired";
            return _response;
        }
        //TODO validate input
        if(userDB.validateAdmin(cookie)){
            //TODO: check that user exists
            userDB.deleteUser(userID);
            _response.status = Status.Success;
        }else{
            _response.status = Status.Failed;
            _response.error = "you are not admin";
        }
        return _response;
    }
    public RoombotResponse updateUser(int userID, string cookie){
        if (!userDB.userExists(cookie)) {
            _response.status = Status.Failed;
            _response.error = "session expired";
            return _response;
        }
        //TODO think of a usecase for updateUser.
        //TODO validate input
        if(userDB.validateAdmin(cookie) || userDB.validateUser(userID, cookie)){
            //TODO: check that user exist
            _response.data = userDB.updateUser(userID, "args");
            _response.status = Status.Success;
        }else{
            _response.status = Status.Failed;
            _response.error = "you are not autorized to that action";
        }
        return _response;
    }
}