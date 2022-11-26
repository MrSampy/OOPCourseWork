using MainForm.Repositories;
using MainForm.Logic;
using MainForm.Users;
using MainForm.ShopExceptions;
using MainForm.Windows;
namespace MainForm
{
    public delegate void MyDelegateOneItem(string data);
    internal partial class Form1 : Form
    {
        BusinessLogic BusinessLogic;
        Person TempPerson;
        private Dictionary<string, Action> actions;


        public Form1(UnitOfWork unitOfWork)
        {
            InitializeComponent();
            BusinessLogic = new BusinessLogic(unitOfWork);
            actions = new Dictionary<string, Action>
            {
                {"Finish your work",CloseForm},
                {"Search for good by name",BusinessLogic.SearcForProductByName},
                {"Sign in account",CloseForm},
                {"Create new account",CloseForm},

            };
            TempPerson = new Guest();
            RefreshMenu();
            
        }
        private void CloseForm() => this.Close();
        private void InvokeItem(object sender, EventArgs e)
        {
            actions[sender.ToString()]();

        }
        private void RefreshMenu() 
        {
            menuToolStripMenuItem.DropDownItems.Clear();
            var items = TempPerson.MenuItems.Select(x => x.Item).ToArray();
            for (var i = 0; i < items.Count(); ++i) 
            {
                items[i].Click += new EventHandler(InvokeItem);
            }
            this.menuToolStripMenuItem.DropDownItems.AddRange(items);
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