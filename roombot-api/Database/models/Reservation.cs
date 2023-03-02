namespace models {
    public class Reservation {
        public int id { get; set; }
        public User user { get; set; }
        public string rom { get; set; }
        public string feideUsername { get; set; }
        public string feidePassword { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public string mode { get; set; }
    }    
}