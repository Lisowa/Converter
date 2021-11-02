using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnitConverter.Logic;

namespace UnitConverter
{
    public partial class FormMain : System.Windows.Forms.Form
    {

        /* Dictionary<string, string> _mapUnit = new Dictionary<string, string>()
         {
             { "meter", "метр" },
             { "yard", "ярд" },
         };

         List<string> _units = new List<string>() { "meter", "yard" };*/

        private List<Category> categories;
        private Category selectedCategory;
        private string selectedUnitFrom;
        private string selectedUnitTo;
        private double enteredValue;
        private Dictionary<string,string> translateCategoriesEnToRu;
        private Dictionary<string, string> translateUnitsEnToRu;
        private List<string> categoriesNameRu;

        public FormMain()
        {
            InitializeComponent();
            
         
            
            CreateCategories();




            comboBoxСategory.DataSource =  categories;//categoriesNameRu;
           

            comboBoxСategory.DisplayMember = "Name";

            /* selectedCategory = categories[0];

             comboBoxUnitTo.DataSource = selectedCategory.UnitList;
             //comboBoxUnitTo.DisplayMember = "Name";
             comboBoxUnitFrom.DataSource  = selectedCategory.UnitList.ToList();
             // comboBoxUnitFrom.DisplayMember = "Name";


             enteredValue = double.Parse(textBoxFrom.Text);
             selectedUnitFrom = comboBoxUnitFrom.Text;
             selectedUnitTo = comboBoxUnitTo.Text;

             */





            /*   var source  = new list<string>();
                 foreach (var unit in _units)
                 {
                     source.add(unit, _mapunit[unit]);
                 }

                 foreach (var item in _mapUnit)
                 {
                     if (item.Value == "метр")
                         item.Key;
                 }

                 comboBoxUnitFrom.DataSource = source;
                 comboBoxUnitFrom.DisplayMember = "Value";
               */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxFrom.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out enteredValue))
            {
                selectedUnitFrom = comboBoxUnitFrom.Text;
                //string selectedUnitToDisplay= (string)comboBoxUnitFrom.SelectedItem;

                if (checkBoxToAllUnits.Checked)
                {
                    string valueWithUnitFrom = enteredValue.ToString() + " " + selectedUnitFrom;
                    string valueWithUnitTo = null;

                    foreach (var unitto in selectedCategory.UnitList)
                    {
                        valueWithUnitTo += selectedCategory.Convert(enteredValue, selectedUnitFrom, unitto).ToString() + " " + unitto + "\r\n\r\n";  
                    }                    

                    var formToAllUnints = new FormToAllUnints(valueWithUnitFrom, valueWithUnitTo);
                    formToAllUnints.ShowDialog();
                }
                else
                {
                    selectedUnitTo = (string)comboBoxUnitTo.SelectedValue;
                    textBoxTo.Text = selectedCategory.Convert(enteredValue, selectedUnitFrom, selectedUnitTo).ToString();
                }
            }
            else
            {
                MessageBox.Show("Допускается ввод только чисел.\nВ качестве разделителя используйте \".\".", "Неверный формат!");
            }

        }

        private void CreateCategories()
        {
            Dictionary<string, double> lenghtUnintsDictionary = new Dictionary<string, double>()
            {
                    { "kilometer",  10},
                    { "foot",       20},
                    { "yard",       30}
            };
            string lenghtBaseUnit = "meter";
            Category lenghtCategory = new Category("Lenght", lenghtUnintsDictionary, lenghtBaseUnit);

            Dictionary<string, double> informationVolumeUnintsDictionary = new Dictionary<string, double>()
            {
                    { "kilobyte",  10e3},
                    { "megabyte",  10e6},
                    { "gigabyte",  10e9},
                    { "kibibyte",  Math.Pow(2,10)},
                    { "mebibyte",  Math.Pow(2,20)},
                    { "gibibyte",  Math.Pow(2,30)}
            };
            string informationVolumeBaseUnit = "byte";
            Category informationVolumeCategory = new Category("Information Volume", informationVolumeUnintsDictionary, informationVolumeBaseUnit);

            categories = new List<Category>();
            categories.Add(lenghtCategory);
            categories.Add(informationVolumeCategory);
            // categories.Add(lenghtCategory);
            // categories.Add(lenghtCategory);
            //categories.Add(lenghtCategory);



            translateCategoriesEnToRu = new Dictionary<string, string>()
            {
                {lenghtCategory.Name, "Длина"},
                

                {informationVolumeCategory.Name, "Объём информации"},
                
            };

            translateUnitsEnToRu = new Dictionary<string, string>()
            {
                
                { "kilometer",  "километр"},
                { "foot",       "фут"},
                { "yard",       "ярд"},
                { "meter",      "метр"},

                
                { "kilobyte",  "Килобайт"},
                { "megabyte",  "Мебибайт"},
                { "gigabyte",  "Гигабайт"},
                { "kibibyte",  "Кибибайт"},
                { "mebibyte",  "Мебибайт"},
                { "gibibyte",  "Гибибайт"},
                { "byte",  "байт"},
            };

            categoriesNameRu = new List<string>();
            
                foreach(var i in translateCategoriesEnToRu)
                {
                    categoriesNameRu.Add(i.Value);
                }
            

        }



        private void comboBoxСategory_SelectedValueChanged(object sender, EventArgs e)
        {
           // categoriesNameRu[]
            selectedCategory = (Category)comboBoxСategory.SelectedValue;

            var tt = CreateTranslations(selectedCategory.UnitList, translateUnitsEnToRu);

            comboBoxUnitTo.DataSource = tt;
            comboBoxUnitTo.ValueMember = "Name";
            comboBoxUnitTo.DisplayMember = "RussianName";

            //comboBoxUnitTo.DataSource = selectedCategory.UnitList;
            comboBoxUnitFrom.DataSource = selectedCategory.UnitList.ToList();
            // comboBoxUnitFrom.DisplayMember = "Name";

            textBoxTo.Text = " ";

            //enteredValue = double.Parse(textBoxFrom.Text);
            //selectedUnitFrom = comboBoxUnitFrom.Text;
            //selectedUnitTo = comboBoxUnitTo.Text;
        }

        private DataTable CreateTranslations(List<string> units, Dictionary<string, string> translations)
        {
            DataTable dataTable = new DataTable();
            DataColumn name = new DataColumn("Name", typeof(string));
            DataColumn ruName = new DataColumn("RussianName", typeof(string));

            dataTable.Columns.Add(name);
            dataTable.Columns.Add(ruName);

            foreach (var item in units)
                dataTable.Rows.Add(item, translations[item]);

            return dataTable;
        }

        private void checkBoxToAllUnits_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBoxToAllUnits.Checked)
            {
                comboBoxUnitTo.Enabled = false;
            }
            else
            {
                textBoxTo.Text = " ";
                comboBoxUnitTo.Enabled = true;
            }
        }
    }

   

   
}
