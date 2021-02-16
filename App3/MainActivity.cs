using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Threading.Tasks;
using System;

namespace App3
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public TextView NumberDisplay { get; private set; }
        public TextView ButtonDisplay { get; private set; }
        public TextView Number { get; private set; }

        public bool button = true;
        public int ans;

        Random rnd = new Random();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            ButtonDisplay = FindViewById<Button>(Resource.Id.activity_button);
            Number = FindViewById<EditText>(Resource.Id.number);
            NumberDisplay = FindViewById<TextView>(Resource.Id.numberdisplay);

            Button activity_button = FindViewById<Button>(Resource.Id.activity_button);
            activity_button.Click += Activity_button_Click;
        }

        private async void Start()
        {
            Button activity_button = FindViewById<Button>(Resource.Id.activity_button);
            activity_button.Enabled = false;

            Number.Text = "";

            int num;
            int sum = 0;
            for(int i = 0; i < 10; i++)
            {
                num = rnd.Next(1, 10);
                sum += num;
                NumberDisplay.Text = num.ToString();
                await Task.Delay(1000);
                NumberDisplay.Text = "";
                await Task.Delay(50);
            }
            NumberDisplay.Text = "答えを入力してください";
            ans = sum;

            activity_button.Enabled = true;
        }

        private void Judge()
        {
            if (Number.Text == ans.ToString())
            {
                NumberDisplay.Text = "正解です";
            }
            else
            {
                NumberDisplay.Text = "それじゃあダメなんよ";
            }
        }

        private void Activity_button_Click(object sender, System.EventArgs e)
        {
            if (button)
            {
                Start();
                button = false;
                ButtonDisplay.Text = "入力";
            }
            else
            {
                Judge();
                ButtonDisplay.Text = "スタート";
                button = true;
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}