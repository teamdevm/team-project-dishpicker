using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using DishPicker.Model;
using DishPicker.ViewModel.Base;

namespace DishPicker.ViewModel
{
    class MainViewModel : BaseViewModel
    {
        public ObservableCollection<Product> Products { get; set; }

        private string time;
        private string day;

        public string Time
        {
            get => time; 
            set => Set(ref time, value);
        }

        public string Day
        {
            get => day;
            set => Set(ref day, value);
        }

        // Конструктор
        public MainViewModel() 
        {
            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 1, 0);
            timer.IsEnabled = true;
            timer.Tick += (o, e) => { Time = DateTime.Now.ToString("HH:mm"); };
            timer.Start();

            time = DateTime.Now.ToString("HH:mm");
            day = ConvertDay();
        }

        private static string ConvertDay()
        {
            return DateTime.Now.ToString("dddd") switch
            {
                "понедельник" => "ПН",
                "вторник" => "ВТ",
                "среда" => "СР",
                "четверг" => "ЧТ",
                "пятница" => "ПТ",
                "суббота" => "СБ",
                "воскресенье" => "ВС",
                _ => "ХЗ",
            };
        }
    }
}
