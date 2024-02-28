using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace XA_Sultan_Aseem
{

    [Activity(Label = "BookActivity")]
    public class BookActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Xamarin.Essentials.Platform.Init(this, bundle);
            // Create your application here

            SetContentView(Resource.Layout.activity_books);

            EditText bookname = FindViewById<EditText>(Resource.Id.bookname);

            Button add = FindViewById<Button>(Resource.Id.add);
            Button clear = FindViewById<Button>(Resource.Id.clear);
            Button logout = FindViewById<Button>(Resource.Id.logout);

            TextView screen = FindViewById<TextView>(Resource.Id.screen);

            MySqliteDB db = new MySqliteDB();

            add.Click += delegate
            {
                db.Insert(bookname.Text);
                screen.Text = db.SelectAllBooks();

            };

            clear.Click += delegate { bookname.Text = ""; };

            logout.Click += delegate
            {
                var i = new Intent(this, typeof(MainActivity));
                StartActivity(i);
            };
        }
    }
}
