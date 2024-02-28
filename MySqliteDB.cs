using System;
using SQLite;
using System.IO;

namespace XA_Sultan_Aseem
{
    class MySqliteDB
    {
        //database path
        string dbPath = Path.Combine(
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "UserBooks.db3");
        public MySqliteDB()
        {
            //Creating database, if it doesn't already exist 
            if (!File.Exists(dbPath))
            {
                var db = new SQLiteConnection(dbPath);
                db.CreateTable<Books>();
                db.CreateTable<Users>();
            }
            //if (db.Table<Departments>().Count() == 0)
        }
        public void Insert(string userName, string pasword, string email, string mobile)
        {
            var db = new SQLiteConnection(dbPath);
            var newUsers = new Users();
            newUsers.username = userName;
            newUsers.password = pasword;
            newUsers.email = email;
            newUsers.mobile = mobile;
            db.Insert(newUsers);
        }

        public void Insert(string bookname)
        {
            var db = new SQLiteConnection(dbPath);
            var newBook = new Books();
            newBook.Bookname = bookname;
            db.Insert(newBook);
        }
        public bool Check(string username, string password)
        {
            var db = new SQLiteConnection(dbPath);
            Console.WriteLine("Reading data From Table");
            var table = db.Table<Users>();
            foreach (var s in table)
            {
                //if(username.Equals(s.username))
                if (string.Equals(s.username, username))
                    if (string.Equals(s.username, password))
                        //if(s.username.Equals(username) && (s.password.Equals(password)))
                        return true;
            }
            return false;
        }
      
        public string SelectAll()
        {
            string data = "";
            var db = new SQLiteConnection(dbPath);
            Console.WriteLine("Reading data From Table");
            var table = db.Table<Users>();
            foreach (var s in table)
            {
                data += s.username + " " + "\n";
            }
            return data;
        }
        public string SelectAllBooks()
        {
            string data = "";
            var db = new SQLiteConnection(dbPath);
            Console.WriteLine("Reading data From Table");
            var table = db.Table<Books>();
            foreach (var s in table)
            {
                data += s.Id + " " + s.Bookname + "\n";
            }
            return data;
        }



        // Teaching Example
        [Table("Users")]
        public class Users
        {
            [PrimaryKey, AutoIncrement, Column("_id")]
            public int ID { get; set; }
            [MaxLength(25)]
            public string username { get; set; }
            [MaxLength(25)]
            public string password { get; set; }
            public string email { get; set; }
            public string mobile { get; set; }
        }

        [Table("Books")]
        public class Books
        {
            [PrimaryKey, AutoIncrement, Column("_id")]
            public int Id { get; set; }
            [MaxLength(8)]
            public string Bookname { get; set; }

        }
    }
}
