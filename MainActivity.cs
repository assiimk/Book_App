using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Widget;
using Java.Lang;
using XA_Sultan_Aseem;

namespace XA_Sultan_Aseem
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity
    {
        Intent i;
        MySqliteDB sq;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            sq = new MySqliteDB();

            EditText username = FindViewById<EditText>(Resource.Id.username);
            EditText password = FindViewById<EditText>(Resource.Id.password);
            Button reg = FindViewById<Button>(Resource.Id.reg);
            Button login = FindViewById<Button>(Resource.Id.login);
            Button close = FindViewById<Button>(Resource.Id.close);

            login.Click += delegate
            {
                if (sq.Check(username.Text, password.Text))
                {
                    i = new Intent(this, typeof(Welcome));
                    i.PutExtra("username", username.Text);
                    StartActivity(i);
                    
                }
                else
                {
                    Toast.MakeText(this, " اسم المستخدم أو كلمة المرور غير صحيحة ", ToastLength.Short).Show();
                }

            };

            reg.Click += delegate
            {
                i = new Intent(this, typeof(Reg));
                StartActivity(i);

            };

            close.Click += delegate
            {
                JavaSystem.Exit(0);
            };


        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}