using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
