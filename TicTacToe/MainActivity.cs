using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace TicTacToe
{
    [Activity(Label = "Kółko i Krzyżyk", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button btn1 = null;
        Button btn2 = null;
        Button btn3 = null;
        Button btn4 = null;
        Button btn5 = null;
        Button btn6 = null;
        Button btn7 = null;
        Button btn8 = null;
        Button btn9 = null;
        Logic Game = new Logic();
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Adjust buttons
            SetContentView(Resource.Layout.Main);
            Button btnStart = FindViewById<Button>(Resource.Id.MyButton);
            btnStart.Click+= new EventHandler(btnStart_click);
            btn1 = FindViewById<Button>(Resource.Id.button1);
            btn1.Tag = 1;
            btn1.Click += new EventHandler(btn_click); 
            btn2 = FindViewById<Button>(Resource.Id.button2);
            btn2.Tag = 2;
            btn2.Click += new EventHandler(btn_click);
            btn3 = FindViewById<Button>(Resource.Id.button3);
            btn3.Tag = 3;
            btn3.Click += new EventHandler(btn_click);
            btn4 = FindViewById<Button>(Resource.Id.button4);
            btn4.Tag = 4;
            btn4.Click += new EventHandler(btn_click);
            btn5 = FindViewById<Button>(Resource.Id.button5);
            btn5.Tag = 5;
            btn5.Click += new EventHandler(btn_click);
            btn6 = FindViewById<Button>(Resource.Id.button6);
            btn6.Tag = 6;
            btn6.Click += new EventHandler(btn_click);
            btn7 = FindViewById<Button>(Resource.Id.button7);
            btn7.Tag = 7;
            btn7.Click += new EventHandler(btn_click);
            btn8 = FindViewById<Button>(Resource.Id.button8);
            btn8.Tag = 8;
            btn8.Click += new EventHandler(btn_click);
            btn9 = FindViewById<Button>(Resource.Id.button9);
            btn9.Tag = 9;
            btn9.Click += new EventHandler(btn_click);
        }

        private void btnStart_click(object sender, EventArgs e)
        {
            newGame();
        }

        private void btn_click(object sender, EventArgs e)
        {
            var Button = sender as Button;
            if (Button == null)
                return;
            Button.Text = Game.GameTurn((int)Button.Tag);
            Button.Enabled = false;

            if (Game.Result != 0)
            {
                switch(Game.Result)
                {
                    case 1:
                        Toast.MakeText(this, "Player O wins!", ToastLength.Short).Show(); break;
                    case 2:
                        Toast.MakeText(this, "Player X wins!", ToastLength.Short).Show(); break;
                    default:
                        Toast.MakeText(this, "Draw!", ToastLength.Short).Show(); break;
                }
                ClearBoard();
            }
        }

        private void ClearBoard()
        {
            btn1.Enabled = false;
            btn2.Enabled = false;
            btn3.Enabled = false;
            btn4.Enabled = false;
            btn5.Enabled = false;
            btn6.Enabled = false;
            btn7.Enabled = false;
            btn8.Enabled = false;
            btn9.Enabled = false;
        }

        private void newGame()
        {
            btn1.Text = "";
            btn2.Text = "";
            btn3.Text = "";
            btn4.Text = "";
            btn5.Text = "";
            btn6.Text = "";
            btn7.Text = "";
            btn8.Text = "";
            btn9.Text = "";
            btn1.Enabled = true;
            btn2.Enabled = true;
            btn3.Enabled = true;
            btn4.Enabled = true;
            btn5.Enabled = true;
            btn6.Enabled = true;
            btn7.Enabled = true;
            btn8.Enabled = true;
            btn9.Enabled = true;
            Game.ClearLogic();
        }
    }
}

