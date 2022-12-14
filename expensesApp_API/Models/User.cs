namespace expensesApp_API.Models
{
    public class User
    {
        public int _id { get; set; }
        public string _name { get; set; }
        public string _email { get; set; }   
        public string _username { get; set; }
        public int _password { get; set; }  
        public string _surname { get; set; }   
        public string _token { get; set; }
        public DateTime _createdAt { get; set; }
        public DateTime _updateAt { get; set; } 
    }
}
