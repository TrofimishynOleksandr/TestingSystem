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
using TestingSystem.DAL.Models;
using TestingSystem.UserControls;

namespace TestingSystem.Pages
{
    /// <summary>
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        Login l;
        Register r;
        TaskCompletionSource<bool> loggedInTaskCompletionSource;
        public RegistrationPage()
        {
            InitializeComponent();
            l = new Login();
            r = new Register();
            loginCC.Content = l;
            registerCC.Content = r;
            loggedInTaskCompletionSource = new TaskCompletionSource<bool>();
            _ = CheckIsLoggedAsync();
        }

        private async Task CheckIsLoggedAsync()
        {
            while (true)
            {
                if (l.IsLogged)
                {
                    if (l.Teacher != null)
                        NavigationService?.Navigate(new TestCreating(l.Teacher));
                    else
                        NavigationService?.Navigate(new TestPassing());
                    loggedInTaskCompletionSource.SetResult(true);
                    break;
                }
                if (r.IsLogged)
                {
                    if (r.Teacher != null)
                        NavigationService?.Navigate(new TestCreating(l.Teacher));
                    else
                        NavigationService?.Navigate(new TestPassing());
                    loggedInTaskCompletionSource.SetResult(true);
                    break;
                }
                await Task.Delay(100);
            }
        }
    }
}
