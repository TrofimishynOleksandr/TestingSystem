using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using TestingSystem.DAL;
using TestingSystem.DAL.Models;
using TestingSystem.DAL.Repositories;
using TestingSystem.UserControls;
using TestingSystem.ViewModels;

namespace TestingSystem.Pages
{
    public class Item
    {
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }

    /// <summary>
    /// Interaction logic for TestCreating.xaml
    /// </summary>
    public partial class TestCreating : Page
    {
        private TestCreatingVM _testCreatingVM;
        private Teacher _teacher;

        public TestCreating(Teacher t)
        {
            InitializeComponent();
            _testCreatingVM = new TestCreatingVM();
            DataContext = _testCreatingVM;
            _teacher = t;
            InitializeGroups();
        }

        private void InitializeGroups()
        {
            try
            {
                using (TestingSystemContext context = new TestingSystemContext())
                {
                    GroupRepository gRepository = new GroupRepository(context);
                    List<Group> groups = gRepository.GetAll().OrderBy(g=> g.Name).ToList();
                    foreach (Group g in groups)
                    {
                        ContentControl contentControl = new ContentControl();
                        contentControl.Content = new GroupSelectItem(g.Name, false);
                        groupsSelectListView.Items.Add(contentControl);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ContentControl contentControl = new ContentControl();
            contentControl.Content = new RawAnswer();
            answersListView.Items.Add(contentControl);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<ContentControl> answers = new List<ContentControl>();
            foreach(ContentControl contentControl in answersListView.Items)
                answers.Add(contentControl);
            if (answers.Any(cc => (cc.Content as RawAnswer).IsRight))
            {
                answers = new List<ContentControl>();
                foreach (ContentControl contentControl in answersListView.Items)
                {
                    ContentControl c = new ContentControl();
                    c.Content = new FinalAnswer()
                    {
                        Text = (contentControl.Content as RawAnswer).Text,
                        IsRight = (contentControl.Content as RawAnswer).IsRight
                    };
                    answers.Add(c);
                }
                questionsListView.Items.Add(
                    new UserControls.Question(_testCreatingVM.Question, answers, double.Parse(numericUpDown.Value)));
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            List<DAL.Models.Question> questions = new List<DAL.Models.Question>();
            foreach (UserControls.Question q in questionsListView.Items)
            {
                List<Answer> answers = new List<Answer>();
                foreach (ContentControl c in q.Answers)
                {
                    FinalAnswer finalAnswer = c.Content as FinalAnswer;
                    Answer a = new Answer()
                    {
                        Title = finalAnswer.Text,
                        IsRight = finalAnswer.IsRight
                    };
                    answers.Add(a);
                }
                DAL.Models.Question question = new DAL.Models.Question() 
                {
                    Title = q.Title,
                    Answers = answers,
                    Value = q.Value
                };
                questions.Add(question);
            }

            Test test = new Test() 
            {
                Title = _testCreatingVM.TestTitle, 
                Questions = questions, 
                Mark = questions.Sum(q => q.Value),
                Creator = _teacher
            };

            try
            {
                using (TestingSystemContext context = new TestingSystemContext())
                {
                    GroupRepository groupRepository = new GroupRepository(context);
                    List<Group> groups = new List<Group>();
                    foreach (ContentControl contentControl in groupsSelectListView.Items)
                    {
                        if ((contentControl.Content as GroupSelectItem).IsSelected)
                        {
                            Group g = groupRepository.GetByName((contentControl.Content as GroupSelectItem).Text);
                            g.Tests.Add(test);
                            groupRepository.Update(g);
                            test.Groups.Add(g);
                        }
                    }
                    TestRepository testRepository = new TestRepository(context);
                    
                    testRepository.Add(test);

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            questionTextBox.Clear();
            answersListView.Items.Clear();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if(answersListView.Items.Count > 0)
                answersListView.Items.RemoveAt(answersListView.Items.Count - 1);
        }
    }
}
