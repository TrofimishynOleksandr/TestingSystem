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
using TestingSystem.DAL;
using TestingSystem.DAL.Models;
using TestingSystem.DAL.Repositories;

namespace TestingSystem.UserControls
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            infoTextBlock.Text = "";
            if (loginTextBox.Text != "" && passwordBox.Password != "")
            {
                using (TestingSystemContext context = new TestingSystemContext())
                {
                    AccountRepository accountRepository = new AccountRepository(context);
                    if(accountRepository.IsExists(loginTextBox.Text))
                    {
                        StudentRepository sRepository = new StudentRepository(context);
                        Student s = new Student()
                        {
                            Login = loginTextBox.Text,
                            Password = passwordBox.Password
                        };
                        Student = sRepository.FindAccount(s);
                        if (Student != null)
                        {
                            IsLogged = true;
                        }
                        else
                        {
                            TeacherRepository tRepository = new TeacherRepository(context);
                            Teacher t = new Teacher()
                            {
                                Login = loginTextBox.Text,
                                Password = passwordBox.Password
                            };
                            Teacher = tRepository.FindAccount(t);
                            if (Teacher != null)
                            {
                                infoTextBlock.Foreground = new SolidColorBrush(Colors.LightGreen);
                                infoTextBlock.Text = "Successfully logged in";
                                IsLogged = true;
                            }
                        }
                    }   
                    else
                    {
                        infoTextBlock.Foreground = new SolidColorBrush(Colors.Red);
                        infoTextBlock.Text = "Incorrect login";
                    }
                }
            }
            else
            {
                infoTextBlock.Foreground = new SolidColorBrush(Colors.Red);
                infoTextBlock.Text = "Enter login and password";
            }
        }

        public bool IsLogged { get; set; }
        public Teacher Teacher { get; set; }
        public Student Student { get; set; }
    }
}
