using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace XA_Sultan_Aseem
{
    [Activity(Label = "reg")]
    public class Reg : Activity
    {

        Intent i;
        MySqliteDB sq;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_reg);
            sq = new MySqliteDB();

            EditText username = FindViewById<EditText>(Resource.Id.username);
            EditText password = FindViewById<EditText>(Resource.Id.password);
            EditText mobile = FindViewById<EditText>(Resource.Id.mobile);
            EditText email = FindViewById<EditText>(Resource.Id.email);
            Button add = FindViewById<Button>(Resource.Id.add);
            Button cancel = FindViewById<Button>(Resource.Id.cancel);
            Button clear = FindViewById<Button>(Resource.Id.clear);


            add.Click += delegate
            {
                sq.Insert(username.Text, password.Text, mobile.Text, email.Text);
                i = new Intent(this, typeof(MainActivity));
                StartActivity(i);
            };

            cancel.Click += delegate
            {
                i = new Intent(this, typeof(MainActivity));
                StartActivity(i);
            };

            clear.Click += delegate {
                username.Text = "";
                password.Text = "";
                mobile.Text = "";
                email.Text = "";

            };

        }
    }
}