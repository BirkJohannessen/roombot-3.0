using context;
using models;
using response;
public class ReservationHelper{
    public UserImpl userDB { get ; set; }
    public ReservationImpl reservationDB { get ; set ; }
    public RoombotResponse _response { get; set; }
    public ReservationHelper(RoombotContext context, RoombotResponse response){
        userDB = new UserImpl(context);
        reservationDB = new ReservationImpl(context);
        _response = response;
    }
    public RoombotResponse fetchUserReservations(string cookie) {
        //TODO validate input
        if (userDB.userExists(cookie)) {
            int userID = userDB.fetchUserByCookie(cookie).id;
            _response.data = reservationDB.fetchUserReservations(userID);
            _response.status = Status.Success;
        } else {
            _response.status = Status.Failed;
            _response.error = "did not validate user";
        }
        return _response;
    }
    public RoombotResponse fetchReservations(string cookie){
        //TODO validate input
        if (!userDB.userExists(cookie)) {
            _response.status = Status.Failed;
            _response.error = "session expired";
            return _response;
        }
        if(userDB.validateAdmin(cookie)){
            _response.data = reservationDB.fetchReservations();
            _response.status = Status.Success;
        }else{
            _response.status = Status.Failed;
            _response.error = "you are not admin";
        }
        return _response;
    }
    public RoombotResponse deleteReservation(int reservationID, string cookie){
        //TODO validate input
        if (!userDB.userExists(cookie)) {
            _response.status = Status.Failed;
            _response.error = "session expired";
            return _response;
        }
        if(reservationDB.validateOwnership(reservationID, cookie) || userDB.validateAdmin(cookie)){
            _response.data = reservationDB.deleteReservation(reservationID);
            _response.status = Status.Success;
        }else{
            _response.status = Status.Failed;
            _response.error = "user does not have access to this action.";
        }
        return _response;
    }
    public RoombotResponse newReservation(string cookie){
        //TODO validate input
        if (!userDB.userExists(cookie)) {
            _response.status = Status.Failed;
            _response.error = "session expired";
            return _response;
        }
        int userID = userDB.fetchUserByCookie(cookie).id;
        _response.data = reservationDB.newReservation(userID);
        _response.status = Status.Success;
        return _response;
    }
}