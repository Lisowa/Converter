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
        private List<Category> categories;
       // private List<string> categories;
        private Category selectedCategory;
        private string selectedUnitFrom;
        private string selectedUnitTo;
        private double enteredValue;
        private Dictionary<string, string> translateCategoriesEnToRu;
        private Dictionary<string, string> translateUnitsEnToRu;
  
        public FormMain()
        {
            InitializeComponent();
            CreateCategories();

            var displayCategories = CreateTranslationsCategory(categories, translateCategoriesEnToRu);
            comboBoxСategory.ValueMember = "Name";
            comboBoxСategory.DisplayMember = "TranslateName";
            comboBoxСategory.DataSource = displayCategories;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxFrom.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out enteredValue))
            {
                //selectedUnitFrom = comboBoxUnitFrom.Text;
                selectedUnitFrom = (string)comboBoxUnitFrom.SelectedValue;

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

        private void comboBoxСategory_SelectedValueChanged(object sender, EventArgs e)
        {
            selectedCategory = (Category)comboBoxСategory.SelectedValue;
            if (selectedCategory == null) return;
            var displayUnitsFrom = CreateTranslations(selectedCategory.UnitList, translateUnitsEnToRu);
            var displayUnitsTo = CreateTranslations(selectedCategory.UnitList, translateUnitsEnToRu);

            comboBoxUnitTo.DataSource = displayUnitsTo;
            comboBoxUnitTo.ValueMember = "Name";
            comboBoxUnitTo.DisplayMember = "TranslateName";

            comboBoxUnitFrom.DataSource = displayUnitsFrom;
            comboBoxUnitFrom.ValueMember = "Name";
            comboBoxUnitFrom.DisplayMember = "TranslateName";

            textBoxTo.Text = " ";
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
          /*
            categories = new List<string>();
            categories.Add(lenghtCategory.Name);
            categories.Add(informationVolumeCategory.Name);
            // categories.Add(lenghtCategory);
            // categories.Add(lenghtCategory);
            //categories.Add(lenghtCategory);
          */
            CreateRuTranslations();
        }

        private void CreateRuTranslations()
        {
            translateCategoriesEnToRu = new Dictionary<string, string>()
            {
                {"Lenght", "Длина"},
                {"Information Volume", "Объём информации"},

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
                { "byte",      "байт"},
            };
        }

        private DataTable CreateTranslations(List<string> listForTranslate, Dictionary<string, string> dictionaryOfTranslations)
        {
            DataTable dataTable = new DataTable();
            DataColumn name = new DataColumn("Name", typeof(string));
            DataColumn translateName = new DataColumn("TranslateName", typeof(string));

            dataTable.Columns.Add(name);
            dataTable.Columns.Add(translateName);

            foreach (var item in listForTranslate)
                dataTable.Rows.Add(item, dictionaryOfTranslations[item]);

            return dataTable;
        }

        private DataTable CreateTranslationsCategory(List<Category> listForTranslate, Dictionary<string, string> dictionaryOfTranslations)
        {
            DataTable dataTable = new DataTable();
            DataColumn name = new DataColumn("Name", typeof(Category));
            DataColumn translateName = new DataColumn("TranslateName", typeof(string));

            dataTable.Columns.Add(name);
            dataTable.Columns.Add(translateName);

            foreach (var item in listForTranslate)
                dataTable.Rows.Add(item, dictionaryOfTranslations[item.Name]);

            return dataTable;
        }
    }
}
