namespace UnitConverter
{
    public partial class FormToAllUnints : System.Windows.Forms.Form
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
