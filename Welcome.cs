using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace XA_Sultan_Aseem
{
    [Activity(Label = "welcome")]
    public class Welcome : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_welcome);

            var screen = FindViewById<TextView>(Resource.Id.screen);
            var logout = FindViewById<Button>(Resource.Id.logout);
            var borrow = FindViewById<Button>(Resource.Id.borrow);
            screen.Text = Intent.GetStringExtra("username");


            logout.Click += delegate
            {

                Intent i = new Intent(this, typeof(MainActivity));
                StartActivity(i);

            };
            borrow.Click += delegate
            {

                Intent i = new Intent(this, typeof(BookActivity));
                StartActivity(i);

            };
        }
    }
}