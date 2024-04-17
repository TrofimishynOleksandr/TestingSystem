using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Pages;

namespace TestingSystem.ViewModels
{
    public class TestCreatingVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _testTitle = "Title";
        public string TestTitle
        {
            get { return _testTitle; }
            set
            {
                _testTitle = value;
                OnPropertyChanged(nameof(TestTitle));
            }
        }

        private string _question = "Question";
        public string Question
        {
            get { return _question; }
            set
            {
                _question = value;
                OnPropertyChanged(nameof(Question));
            }
        }
    }
}
