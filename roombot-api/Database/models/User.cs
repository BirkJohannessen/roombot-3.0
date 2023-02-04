namespace models {
    public class User {
        public int id { get; set; }
        public bool admin { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string cookie { get; set; }
        public ICollection<Reservation> reservations { get; set; }
    }
}