using MainForm.Repositories;
using MainForm.Logic;
using MainForm.Users;
using MainForm.ShopExceptions;

namespace MainForm
{
    internal partial class Form1 : Form
    {
        BusinessLogic BusinessLogic;

        public Form1(UnitOfWork unitOfWork)
        {
            InitializeComponent();
            BusinessLogic = new BusinessLogic(unitOfWork);

        }

        private void Enter_Click(object sender, EventArgs e)
        {
            User user;
            try
            {
                user = BusinessLogic.TryEnter(Nickname.Text,Password.Text);
            }
            catch (MarketException exc) 
            {
                MessageBox.Show(exc.Message);
                return;
            }

            MessageBox.Show("Ok");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            BusinessLogic.ShowAllProducts();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            User user;
            try
            {
                user = BusinessLogic.TryCreateNewUser(Nickname.Text, Password.Text);
            }
            catch (MarketException exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }

            MessageBox.Show("Ok");
        }

    }
}