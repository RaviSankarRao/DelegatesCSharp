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

namespace SampleWPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        List<Person> people = new List<Person>
        {
            new Person { FirstName = "John", LastName = "Doe" },
            new Person { FirstName = "Tony", LastName = "Stark" },
            new Person { FirstName = "Steve", LastName = "Rogers" },
            new Person { FirstName = "Bruce", LastName = "Banner" },
            new Person { FirstName = "Natasha", LastName = "Romanoff" },
            new Person { FirstName = "Stephen", LastName = "Strange" },
        };

        #region Using Custom Delegates

        // PersonFormatter is a delegate 
        //      - parameter - Person
        //      - returns - string
        public PersonFormatter formatter;

        // Functions assigned to delegates
        public void AssignFormatter()
        {
            if (rdBtn_Default.IsChecked.Value)
                formatter = NameFormatter.Default;
            else if (rdBtn_LastNameFirst.IsChecked.Value)
                formatter = NameFormatter.LastNameFirst;
            else if (rdBtn_FirstNameOnly.IsChecked.Value)
                formatter = NameFormatter.FirstNameOnly;
            else if (rdBtn_LastNameOnly.IsChecked.Value)
                formatter = NameFormatter.LastNameOnly;
        }

        private void DisplayName_Click(object sender, RoutedEventArgs e)
        {
            namesList.Items.Clear();

            AssignFormatterLamdaExpression();

            foreach (var person in people)
                namesList.Items.Add(person.ToString(formatter));
        }

        #endregion

        #region Lambda Expressions as Delegates

        // Lambda expressions as delegates
        public void AssignFormatterLamdaExpression()
        {
            // Anonymous functions as delegates
            if (rdBtn_Default.IsChecked.Value)
                formatter = delegate (Person person)
                {
                    return $"{person.FirstName} {person.LastName}";
                };

            // Removed delegate keyword
            // Using lamdba operator
            else if (rdBtn_LastNameFirst.IsChecked.Value)
                formatter = (Person person) =>
                {
                    return $"{person.LastName} {person.FirstName}";
                };

            // C#'s Type Inference in action
            // Removed explicit type naming for person parameter
            else if (rdBtn_FirstNameOnly.IsChecked.Value)
                formatter = (person) =>
                {
                    return person.FirstName;
                };

            // Single parameter - No brackets required
            // Expression function - Single statement, No curly brackets required
            else if (rdBtn_LastNameOnly.IsChecked.Value)
                formatter = person => person.LastName;
        }

        #endregion

        #region Using Func<> as Delegates
        Func<Person, string> formatterFunc;

        public void AssignFomratterFunc()
        {
            if (rdBtn_Default.IsChecked.Value)
                formatterFunc = p => $"{p.FirstName} {p.LastName}";

            else if (rdBtn_LastNameFirst.IsChecked.Value)
                formatterFunc = p => $"{p.LastName} {p.FirstName}";

            else if (rdBtn_FirstNameOnly.IsChecked.Value)
                formatterFunc = p => p.FirstName;

            else if (rdBtn_LastNameOnly.IsChecked.Value)
                formatterFunc = p => p.LastName;
        }

        private void DisplayName_Func_Click(object sender, RoutedEventArgs e)
        {
            namesList.Items.Clear();

            AssignFomratterFunc();

            foreach (var person in people)
                namesList.Items.Add(person.ToString(formatterFunc));
        }

        #endregion

        private async void DisplayName_Async_Click(object sender, RoutedEventArgs e)
        {
            await PerformRequiredAction();
        }

        public async Task PerformRequiredAction()
        {
            messagesList.Items.Add($"Button clicked at {DateTime.Now.ToString("hh-mm-ss")}");
            AssignFormatterLamdaExpression();

            await Task.Delay(3000);

            // namesList.Items.Clear();

            foreach (var person in people)
                namesList.Items.Add(person.ToString(formatter));
        }
    }
}
