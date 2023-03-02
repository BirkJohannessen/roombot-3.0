namespace requests {
    public class Login {
        public string _username { get; set; }
        public string _password { get; set; }
        public Login(){ }
        public Login(string username, string password){
            _username = username;
            _password = password;
        }
    }
}