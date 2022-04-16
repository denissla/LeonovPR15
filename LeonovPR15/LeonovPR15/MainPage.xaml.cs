using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeonovPR15
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        bool active = false;
        TimeSpan time = new TimeSpan(0, 0, 0);
        public MainPage()
        {
            InitializeComponent();
        }


        bool TimerTick()
        {
            if (active)
            {
                time += TimeSpan.FromSeconds(0.1);
                lable1.Text = time.ToString(@"hh\:mm\:ss\:ff");
                return true;
            }
            else
            {
                return false;
            }
        }

        private async void Button1_Clicked(object sender, EventArgs e)
        {
            active = !active;
            if (active)
            {
                button1.Text = "Стоп";
                time = new TimeSpan(0, 0, 0);
                Device.StartTimer(TimeSpan.FromSeconds(0.1), TimerTick);

            }
            else
            {
                button1.Text = "Старт";
                lable1.Text = title.Text + " / " + DateTime.Now + " / " + lable1.Text;
                await App.DataBase.SaveTimeAsync(new Time() { Title = title.Text, Date = DateTime.Now, Interval = time });
            }

        }
    }
}