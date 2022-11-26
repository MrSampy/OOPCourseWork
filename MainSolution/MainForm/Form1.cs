using MainForm.Repositories;
using MainForm.Logic;
using MainForm.Users;
using MainForm.ShopExceptions;
using MainForm.Windows;
namespace MainForm
{
    public delegate void MyDelegateOneItem(string data);
    public delegate void MyDelegateTwoItem(string data1, string data2);
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
                {"Sign in account",EnterUser},
                {"Create new account",RegisterUser},

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

        private void EnterUser() 
        {
            User user;
            string nickname = string.Empty;
            string password = string.Empty;
            var dialog = new RegUserForm("Enter", new MyDelegateTwoItem((string data1,string data2) => 
            {
                nickname = data1;
                password = data2;
            }));
            dialog.ShowDialog();
            try
            {
                user = BusinessLogic.TryEnter(nickname, password);
            }
            catch (MarketException exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }
           
            TempPerson = user;
            RefreshMenu();

        }
        private void RegisterUser()
        {
            User user;
            string nickname = string.Empty;
            string password = string.Empty;
            var dialog = new RegUserForm("Register", new MyDelegateTwoItem((string data1, string data2) =>
            {
                nickname = data1;
                password = data2;
            }));
            dialog.ShowDialog();
            try
            {
                user = BusinessLogic.TryCreateNewUser(nickname, password);
            }
            catch (MarketException exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }

            TempPerson = user;
            RefreshMenu();

        }
    

    }
}