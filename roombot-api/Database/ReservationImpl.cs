using context;
using models;
public class ReservationImpl{

    private readonly RoombotContext _context;
    private readonly UserImpl _userDB;
    public ReservationImpl(RoombotContext context){
        _context = context;
        _userDB = new UserImpl(context);
    }
    public bool validateOwnership(int reservationID, string cookie){
        try{
            User user = _context.tbl_users.Single( user => user.cookie == cookie );
            Reservation reservation = _context.tbl_reservations.Single( reservation => reservation.id == reservationID );
            return reservation.user.id == user.id;
        }catch(Exception){
            return false;
        }
    }
    public List<Reservation> fetchUserReservations(int userID){
        User user = _context.tbl_users.Single( user => user.id == userID );
        return (List<Reservation>) user.reservations;
    }
    public List<Reservation> fetchReservations(){
        return _context.tbl_reservations.ToList();
    }
    public bool deleteReservation(int reservationID){
        Reservation reservation = _context.tbl_reservations.Single( reservation => reservation.id == reservationID );
        _context.Remove<Reservation>(reservation);
        return true;
    }
    public bool newReservation(int userID){
        //base64 encode feidepassword
        User user = _userDB.fetchUser(userID);
        Reservation reservation = new Reservation { user = user, rom = "test", feideUsername="test", feidePassword="test", from="08:00", to="09:00", mode="kont"};
        _context.Add<Reservation>(reservation);
        _context.SaveChanges();
        return true;
    }
}