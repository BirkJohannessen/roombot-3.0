using models;

namespace response {
    public class RoombotResponse {
        public Status status { set; get; }
        public string? error { set; get; }
        public object? data { set; get; }

        public RoombotResponse(){
            status = Status.Default;
            error = null;
            data = null;
        }
    }
}