using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestingSystem.UserControls
{
    /// <summary>
    /// Interaction logic for Question.xaml
    /// </summary>
    public partial class Question : UserControl
    {
        public Question(string title, IEnumerable<ContentControl> answers, double value)
        {
            Title = title;
            Answers = answers;
            InitializeComponent();
            DataContext = this;
            Value = value;
        }

        public string Title { get; set; }
        public IEnumerable<ContentControl> Answers { get; set; }
        public double Value { get; set; }
    }
}
