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
                {"Search for good by name",SearcForProductByName},
                {"Sign in account",EnterUser},
                {"Create new account",RegisterUser},
                {"View the list of goods",ShowAllProducts},
                {"Sign out",LogOut },
                {"Change Profile",ChangeProfile },
                {"Create new order",CreateNewOrder },
                {"Ordering",CloseForm },
                {"Cancellation" ,CloseForm },
                {"Review the history of orders",CloseForm },
                {"Setting the status of the order Received",CloseForm },
                {"Add new product",CreateProduct },
                {"Change description about the product",ChangeProductDesc },
                {"View personal information of users",ShowAllUsers },
                {"Change personal information of user",ChangePersonalInfoOfUser },
                {"Change the status of the order",CloseForm },
                {"Cancellation by admin",CloseForm }

            };
            TempPerson = new Guest();
            RefreshMenu();

        }
        private void ChangePersonalInfoOfUser()
        {

            try
            {
                BusinessLogic.ChangePersonalInfoOfUser();
            }
            catch (MarketException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }
        private void ShowAllUsers()
        {
            try
            {
                BusinessLogic.ShowAllUsers();
            }
            catch (MarketException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }
        private void ChangeProductDesc()
        {

            try
            {
                BusinessLogic.ChangeProductDesc();
            }
            catch (MarketException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }
        private void CreateProduct()
        {

            try
            {
                BusinessLogic.CreateProduct();
            }
            catch (MarketException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }
        private void SearcForProductByName() 
        {

            try
            {
                BusinessLogic.SearcForProductByName();
            }
            catch (MarketException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }
        private void ShowAllProducts()
        {

            try
            {
                BusinessLogic.ShowAllProducts();
            }
            catch (MarketException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }
        private void LogOut()
        {
            if (!BusinessLogic.CheckChoice("Are you sure, that you want to sign out?"))
                return;
            TempPerson = new Guest();
            RefreshMenu();
            profileInfo.Text = "Hello, dear guest!";
        }

        private void CreateNewOrder() 
        {
            try
            {
                BusinessLogic.CreateNewOrder(TempPerson.GetName());
            }
            catch (MarketException ex) 
            {
                MessageBox.Show(ex.Message);
                return;
            }
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