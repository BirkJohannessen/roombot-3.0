
public class ReservationHelper{
    public UserImpl userDB { get ; set; }
    public ReservationImpl reservationDB { get ; set ; }
    public ReservationHelper(){
        userDB = new UserImpl();
        reservationDB = new ReservationImpl();
    }
    public string fetchUserReservations(int reservationID, string cookie, int userID){
        if(reservationDB.validateOwnership(reservationID, cookie) || userDB.validateAdmin(cookie)){
            return reservationDB.fetchUserReservations(userID);
        }else{
            return "";
        }
    }
    public string fetchReservations(string cookie){
        if(userDB.validateAdmin(cookie)){
            return reservationDB.fetchReservations();
        }else{
            return "";
        }
    }
    public string deleteReservation(int reservationID, string cookie){
        if(reservationDB.validateOwnership(reservationID, cookie) || userDB.validateAdmin(cookie)){
            return reservationDB.deleteReservation(reservationID);
        }else{
            return "";
        }
    }
    public string newReservation(int userID, string cookie){
        if(userDB.validateUser(userID, cookie)){
            return reservationDB.newReservation(userID);
        }else{
            return "";
        }
    }
}