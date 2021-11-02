using System.Windows.Forms;

namespace UnitConverter
{
    public partial class FormToAllUnints : Form
    {
        public FormToAllUnints()
        {
            InitializeComponent();
        }

        public FormToAllUnints(string valueWithUnitFrom, string valueWithUnitTo)
        {
            InitializeComponent();
            textBoxFrom.Text = valueWithUnitFrom;
            textBoxTo.Text = valueWithUnitTo;
        }
    }
}
