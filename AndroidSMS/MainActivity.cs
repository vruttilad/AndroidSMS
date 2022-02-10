using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using Xamarin.Essentials;

namespace AndroidSMS
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText editTxt1, editTxt2;
        Button button;
        string messageText;
        string recipient;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            EditText editTxt1 = FindViewById<EditText>(Resource.Id.editText1);
            EditText editTxt2 = FindViewById<EditText>(Resource.Id.editText2);
            Button button = FindViewById<Button>(Resource.Id.button1);
            editTxt1.Text = recipient;
            editTxt2.Text = messageText;
            button.Click += Button_Click;

        }

        private void Button_Click(object sender, EventArgs e)
        {
            var message = new SmsMessage(messageText, new string[] {recipient});
            Sms.ComposeAsync(message);

        }

        private void SendSms(string messageText, string editTxt1)
        {
            
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}