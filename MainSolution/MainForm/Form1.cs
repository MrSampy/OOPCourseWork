using MainForm.Repositories;
using MainForm.Logic;
using MainForm.Users;
using MainForm.ShopExceptions;

namespace MainForm
{
    internal partial class Form1 : Form
    {
        BusinessLogic BusinessLogic;
        Person TempPerson;
        public Form1(UnitOfWork unitOfWork)
        {
            InitializeComponent();
            BusinessLogic = new BusinessLogic(unitOfWork);
            TempPerson = new Guest();
            RefreshMenu();
        }

        private void RefreshMenu() 
        {
            menuToolStripMenuItem.DropDownItems.Clear();
            this.menuToolStripMenuItem.DropDownItems.AddRange(TempPerson.MenuItems.Select(x=>x.Item).ToArray());
        }
        /*
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

        private void finishYourWork_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void searchForGoodByName_Click(object sender, EventArgs e)
        {

        }*/
        
    }
}