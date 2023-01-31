
public class RegiterHelper{
    public UserImpl userDB { get ; set; }
    public ReservationImpl reservationDB { get ; set ; }
    public RegiterHelper(){
        userDB = new UserImpl();
        reservationDB = new ReservationImpl();
    }
    public static string fetchUserReservations(int reservationID, string cookie, userID){
        if(reservationDB.validateOwnership(reservationID, cookie) || userDB.validateAdmin(cookie)){
            reservationDB.fetchUserReservations(int userID);
        }else{
            return "";
        }
    }
    public static string fetchReservations(string cookie){
        if(userDB.validateAdmin(cookie)){
            reservationDB.fetchReservations();
        }else{
            return "";
        }
    }
    public static string deleteReservation(int reservationID, string cookie){
        if(reservationDB.validateOwnership(reservationID, cookie)){
            reservationDB.deleteReservation(reservationID);
        }else{
            return "";
        }
    }
    public static string newReservation(int userID, string cookie){
        if(userDB.validateUser(userID, cookie)){
            reservationDB.newReservation(userID);
        }else{
            return "";
        }
    }
}