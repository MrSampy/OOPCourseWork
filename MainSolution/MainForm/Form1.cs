using MainForm.Repositories;
using MainForm.Logic;
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

        }

        private void button2_Click(object sender, EventArgs e)
        {
            BusinessLogic.ShowAllProducts();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

    }
}