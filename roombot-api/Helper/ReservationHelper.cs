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
        if(reservationDB.validateOwnership(reservationID, cookie) || userDB.validateAdmin(cookie)){
            _response.data = reservationDB.deleteReservation(reservationID);
            _response.status = Status.Success;
        }else{
            _response.status = Status.Failed;
            _response.error = "did not validate user";
        }
        return _response;
    }
    public RoombotResponse newReservation(string cookie){
        int userID = userDB.fetchUserByCookie(cookie).id;
        if(userDB.validateUser(userID, cookie)){
            _response.data = reservationDB.newReservation(userID);
            _response.status = Status.Success;
        }else{
            _response.status = Status.Failed;
            _response.error = "did not validate user";
        }
        return _response;
    }
}