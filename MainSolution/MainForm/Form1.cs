using MainForm.Repositories;
using MainForm.Logic;
using MainForm.Users;
using MainForm.ShopExceptions;
using MainForm.Windows;
using MainForm.Menu;
using System.Windows.Forms;

namespace MainForm
{
    public delegate void MyDelegateOneItem<T>(T data);
    public delegate void MyDelegateTwoItem(string data1, string data2);
    public delegate void MyDelegateFourItem(string data1, string data2, string data3, string data4);
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
                {"View the list of goods",BusinessLogic.ShowAllProducts},
                {"Sign out",LogOut },
                {"Change Profile",ChangeProfile },
                {"Create new order",CloseForm },
                {"Ordering",CloseForm },
                {"Cancellation" ,CloseForm },
                {"Review the history of orders",CloseForm },
                {"Setting the status of the order Received",CloseForm },
                {"Add new product",BusinessLogic.CreateProduct },
                {"Change description about the product",BusinessLogic.ChangeProductDesc },
                {"View personal information of users",BusinessLogic.ShowAllUsers },
                {"Change personal information of user",CloseForm },
                {"Change the status of the order",CloseForm },
                {"Cancellation by admin",CloseForm }

            };
            TempPerson = new Guest();
            RefreshMenu();

        }
        private void LogOut()
        {
            if (!BusinessLogic.CheckChoice("Are you sure, that you want to sign out?"))
                return;
            TempPerson = new Guest();
            RefreshMenu();
            profileInfo.Text = "Hello, dear guest!";
        }


        private void ChangeProfile() 
        {
            var newProdile = string.Empty;
            try
            {
                newProdile = BusinessLogic.ChangeProfile(TempPerson);
            }
            catch(MarketException exc) 
            {
                MessageBox.Show(exc.Message);
                return;
            }
            profileInfo.Text = newProdile;
        
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
            var dialog = new RegUserForm("Sign In", new MyDelegateTwoItem((string data1,string data2) => 
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
            profileInfo.Text = user.ProfileInfo;

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
            profileInfo.Text = user.ProfileInfo;
        }
    

    }
}