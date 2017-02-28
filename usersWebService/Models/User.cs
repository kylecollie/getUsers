namespace usersWebService.Model
{
    public class User
    {
        public int userID { get; set; }
        public string firstname { get; set; }
        public string lasname { get; set; }
        public string username { get; set; }
        public string favoriteColor { get; set; }

        public User()
        {
        }

        public User(int id, string fn, string ln, string un, string fc)
        {
            this.userID = id;
            this.firstname = fn;
            this.lasname = ln;
            this.username = un;
            this.favoriteColor = fc;
        }
    }
}
