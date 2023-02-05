using context;
public class ReservationImpl{

    private readonly RoombotContext _context;
    public ReservationImpl(RoombotContext context){
        _context = context;
    }
    public bool validateOwnership(int reservationID, string cookie){
        //TODO
        return true;
    }
    public string fetchUserReservations(int userID){
        //TODO
        return "user reservation"+userID;
    }
    public string fetchReservations(){
        //TODO
        return "all reservations";
    }
    public string deleteReservation(int reservationID){
        //TODO
        return "delete reservation"+reservationID;
    }
    public string newReservation(int userID){
        //TODO
        return "new reservation"+userID;
    }
}