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
                {"Ordering",Ordering },
                {"Cancellation" ,CancellOrderByUser },
                {"Review the history of orders",ShowAllOrdersOfUser },
                {"Setting the status of the order Received",SetStatusReceive },
                {"View all orders",ShowAllOrders },
                {"Add new product",CreateProduct },
                {"Change description about the product",ChangeProductDesc },
                {"View personal information of users",ShowAllUsers },
                {"Change personal information of user",ChangePersonalInfoOfUser },
                {"Setting the status of the order Sent",SetStatusSent },
                {"Setting the status of the order Completed",SetStatusCompleted },
                {"Cancellation by admin",CancellByAdmin }

            };
            TempPerson = new Guest();
            RefreshMenu();

        }

        private void CancellByAdmin()
        {

            try
            {
                BusinessLogic.ChangeStatus(BusinessLogic.GetOrdersToCancellAdmin(), Orders.OrderStatus.Canceled_by_the_administrator,
                    "Are you sure, you want to cancell the order?");
            }
            catch (MarketException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }
        private void SetStatusCompleted()
        {

            try
            {
                BusinessLogic.ChangeStatus(BusinessLogic.GetOrdersToConpleted(), Orders.OrderStatus.Completed,
                    "Are you sure, you want to complete the order?");
            }
            catch (MarketException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }
        private void SetStatusSent()
        {

            try
            {
                BusinessLogic.ChangeStatus(BusinessLogic.GetOrdersToSent(), Orders.OrderStatus.Sent,
                    "Are you sure, you want to send the order?");
            }
            catch (MarketException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

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
        private void Ordering()
        {

            try
            {
                BusinessLogic.ChangeStatus(BusinessLogic.GetOrdersToPay(TempPerson.GetName()),Orders.OrderStatus.Payment_received,
                    "Are you sure, you want to pay for order?");
            }
            catch (MarketException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }
        private void SetStatusReceive()
        {
            try
            {
                BusinessLogic.ChangeStatus(BusinessLogic.GetOrdersToReceive(TempPerson.GetName()), Orders.OrderStatus.Received,
                    "Are you sure, you want to receive the order?");
            }
            catch (MarketException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        private void CancellOrderByUser()
        {

            try
            {
                BusinessLogic.ChangeStatus(BusinessLogic.GetOrdersToCancellUser(TempPerson.GetName()), Orders.OrderStatus.Canceled_by_user,
                    "Are you sure, you want to cancell your order?");
            }
            catch (MarketException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }
        private void ShowAllUsers() => BusinessLogic.ShowAllUsers();
        private void ShowAllOrders() => BusinessLogic.ShowAllOrders();
        private void ShowAllOrdersOfUser()
        {

            try
            {
                BusinessLogic.ShowAllOrdersOfUser(TempPerson.GetName());
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
        private void ShowAllProducts() => BusinessLogic.ShowAllProducts();

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
                items[i].Click -= new EventHandler(InvokeItem);
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