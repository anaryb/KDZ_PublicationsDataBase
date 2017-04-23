
using System.Windows;


namespace PublicationsDatabase
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class NewPublicationWindow : Window
    {
         public NewPublicationWindow()
         {
             InitializeComponent();
         }

        Publication _newPublication;

        public Publication NewPublication
        {
            get { return _newPublication; }
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            int publishYear;
            if (string.IsNullOrWhiteSpace(textBoxTitle.Text))
            {
                MessageBox.Show("Необходимо ввести название публикации");
                textBoxTitle.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxAuthors.Text))
            {
                MessageBox.Show("Необходимо ввести автора публикации");
                textBoxAuthors.Focus();
                return;
            }
            if (!int.TryParse(textBoxPublishYear.Text, out publishYear))
            {
                MessageBox.Show("Неккоректный ввод года публикации");
                textBoxPublishYear.Focus();
                return;
            }
            if (publishYear < 0 || publishYear > 2018)
            {
                MessageBox.Show("Год должен быть не меньше 0 и не больше 2017");
                textBoxPublishYear.Focus();
                return;
            }
            if (comboBoxPublicationType.Text == "")
            {
                MessageBox.Show("Выберите значение типа публикации");
                comboBoxPublicationType.Focus();
                return;
            }

            int citedreferences;
            if (!int.TryParse(textBoxCitedReferences.Text, out citedreferences))
            {
                MessageBox.Show("Неккоректный ввод количества ссылок");
                textBoxCitedReferences.Focus();
                return;
            }

            int timescited;
            if (!int.TryParse(textBoxTimesCited.Text, out timescited))
            {
                MessageBox.Show("Неккоректный ввод числа статей, которые ссылались на эту статью");
                textBoxTimesCited.Focus();
                return;
            }


            _newPublication = new Publication(comboBoxPublicationType.Text, textBoxAuthors.Text, textBoxTitle.Text, citedreferences, timescited, textBoxISSN_ISBN.Text, publishYear);

            // Accept the dialog and return the dialog result
            this.DialogResult = true;


        }


    }
}
