using System.Text;
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
using TestingSystem.Pages;
using TestingSystem.UserControls;

namespace TestingSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FillDb();
            pageFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            pageFrame.NavigationService.Navigate(new RegistrationPage());
        }

        private void FillDb()
        {
            using (var context = new TestingSystemContext())
            {
                if (context.Teachers.Count() == 0 && context.Groups.Count() == 0)
                {
                    List<Group> groups = new List<Group>
            {
                new Group { Name = "TV-31" },
                new Group { Name = "TV-32" },
                new Group { Name = "TV-33" },
                new Group { Name = "TV-21" },
                new Group { Name = "TV-22" },
                new Group { Name = "TV-23" }
            };

                    List<Teacher> teachers = new List<Teacher>
            {
                new Teacher { Login = "login1", Password = "password1", FullName = "Teacher1" },
                new Teacher { Login = "login2", Password = "password2", FullName = "Teacher2" },
                new Teacher { Login = "login3", Password = "password3", FullName = "Teacher3" }
            };

                    teachers[0].Groups.AddRange(groups.Take(2));
                    teachers[1].Groups.AddRange(groups.Skip(2).Take(2));
                    teachers[2].Groups.AddRange(groups.Skip(4));

                    foreach (var group in groups)
                    {
                        foreach (var teacher in group.Teachers)
                        {
                            teacher.Groups.Add(group);
                        }

                        context.Groups.Add(group);
                    }

                    foreach (var teacher in teachers)
                    {
                        context.Teachers.Add(teacher);
                    }

                    context.SaveChanges();
                }
            }
        }
    }
}