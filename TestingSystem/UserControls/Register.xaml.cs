using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : UserControl
    {
        public Register()
        {
            InitializeComponent();
            using (TestingSystemContext context = new TestingSystemContext())
            {
                GroupRepository groupRepository = new GroupRepository(context);
                groupsComboBox.ItemsSource = groupRepository.GetAll().Select(g => g.Name).ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (loginTextBox.Text != "" && passwordBox.Password != "")
            {
                using (TestingSystemContext context = new TestingSystemContext())
                {
                    AccountRepository accountRepository = new AccountRepository(context);
                    if (!accountRepository.IsExists(loginTextBox.Text))
                    {
                        if ((bool)teacherRB.IsChecked)
                        {
                            Teacher = new Teacher()
                            {
                                Login = loginTextBox.Text,
                                Password = passwordBox.Password,
                                FullName = fullNameTextBox.Text,
                                Groups = new List<Group>()
                            };
                            TeacherRepository tRepository = new TeacherRepository(context);
                            tRepository.Add(Teacher);
                            tRepository.SaveChanges();
                            infoTextBlock.Foreground = new SolidColorBrush(Colors.LightGreen);
                            infoTextBlock.Text = "Successfully registered new account";
                            IsLogged = true;
                        }
                        else
                        {
                            if (groupsComboBox.SelectedItem != null)
                            {
                                GroupRepository gRepository = new GroupRepository(context);
                                Student = new Student()
                                {
                                    Login = loginTextBox.Text,
                                    Password = passwordBox.Password,
                                    FullName = fullNameTextBox.Text,
                                    Tests = new List<Test>(),
                                    Group = gRepository.GetByName(groupsComboBox.SelectedItem.ToString())
                                };
                                StudentRepository sRepository = new StudentRepository(context);
                                sRepository.Add(Student);
                                sRepository.SaveChanges();
                                infoTextBlock.Foreground = new SolidColorBrush(Colors.LightGreen);
                                infoTextBlock.Text = "Successfully registered new account";
                                IsLogged = true;
                            }
                            else
                            {
                                infoTextBlock.Foreground = new SolidColorBrush(Colors.Red);
                                infoTextBlock.Text = "Select your group";
                            }
                        }
                    }
                    else
                    {
                        infoTextBlock.Foreground = new SolidColorBrush(Colors.Red);
                        infoTextBlock.Text = "This login is already taken";
                    }
                }
            }
            else
            {
                infoTextBlock.Foreground = new SolidColorBrush(Colors.Red);
                infoTextBlock.Text = "Enter login and password";
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if((bool)studentRB.IsChecked)
                groupsComboBox.IsEnabled = true;
            else
                groupsComboBox.IsEnabled = false;
        }

        public bool IsLogged { get; set; }
        public Teacher Teacher { get; set; }
        public Student Student { get; set; }
    }
}
