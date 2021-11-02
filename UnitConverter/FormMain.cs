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

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxFrom.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out enteredValue))
            {
                //selectedUnitFrom = comboBoxUnitFrom.Text;
                selectedUnitFrom = (string)comboBoxUnitFrom.SelectedValue;

                if (checkBoxToAllUnits.Checked)
                {
                    string valueWithUnitFrom = enteredValue.ToString() + " " + translateUnitsEnToRu[selectedUnitFrom];
                    string valueWithUnitTo = null;

                    foreach (var unitto in selectedCategory.UnitList)
                    {
                        valueWithUnitTo += selectedCategory.Convert(enteredValue, selectedUnitFrom, unitto).ToString() + " " + translateUnitsEnToRu[unitto] + "\r\n\r\n";
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
                    { "kilometer",  1e-3},
                    { "millimeter", 1e3},
                    { "centimeter", 1e2},
                    { "foot",       3.28084},
                    { "yard",       1.09361},
                    { "inch",       39.3701},
                    { "mile",       (double)1/1609},
            };
            string lenghtBaseUnit = "meter";
            Category lenghtCategory = new Category("Lenght", lenghtUnintsDictionary, lenghtBaseUnit);

            Dictionary<string, double> informationVolumeUnintsDictionary = new Dictionary<string, double>()
            {
                    { "kilobyte",  1e-3},
                    { "megabyte",  1e-6},
                    { "gigabyte",  1e-9},
                    { "kibibyte",  1/Math.Pow(2,10)},
                    { "mebibyte",  1/Math.Pow(2,20)},
                    { "gibibyte",  1/Math.Pow(2,30)}
            };
            string informationVolumeBaseUnit = "byte";
            Category informationVolumeCategory = new Category("Information Volume", informationVolumeUnintsDictionary, informationVolumeBaseUnit);

            Dictionary<string, double> MassUnintsDictionary = new Dictionary<string, double>()
            {
                    { "gram",           1e3},
                    { "British ton",    (double)1/1016},
                    { "American ton",   (double)1/907},
                    { "pound",          2.2046},
                    { "ounce",          35.274},
            };
            string MassBaseUnit = "kilogram";
            Category MassCategory = new Category("Mass", MassUnintsDictionary, MassBaseUnit);

            Dictionary<string, double> FlatAngleUnintsDictionary = new Dictionary<string, double>()
            {
                    { "gon",            (double)200/180},
                    { "angular minute", 60},
                    { "angular second", 3600},
                    { "rad",            Math.PI/180},
            };
            string FlatAngleBaseUnit = "angular degree";
            Category FlatAngleCategory = new Category("Flat Angle", FlatAngleUnintsDictionary, FlatAngleBaseUnit);

            Dictionary<string, double> SquareUnintsDictionary = new Dictionary<string, double>()
            {
                    { "square kilometer", 1e-6},
                    { "hectare",          1e-4},
                    { "acre",             (double)1/4047},
                    { "square inch",      1550},
            };
            string SquareBaseUnit = "square meter";
            Category SquareCategory = new Category("Square", SquareUnintsDictionary, SquareBaseUnit);

            categories = new List<Category>();
            categories.Add(lenghtCategory);
            categories.Add(informationVolumeCategory);
            categories.Add(MassCategory);
            categories.Add(FlatAngleCategory);
            categories.Add(SquareCategory);

            CreateRuTranslations();
        }

        private void CreateRuTranslations()
        {
            translateCategoriesEnToRu = new Dictionary<string, string>()
            {
                {"Lenght", "Длина"},
                {"Information Volume", "Объём информации"},
                {"Mass", "Масса"},
                {"Flat Angle", "Плоский угол"},
                {"Square", "Площадь"},
            };

            translateUnitsEnToRu = new Dictionary<string, string>()
            {
                { "kilometer",  "Километр"},
                { "foot",       "Фут"},
                { "yard",       "Ярд"},
                { "meter",      "Метр"},
                { "millimeter", "Миллиметр"},
                { "centimeter", "Сантиметр"},
                { "inch",       "Дюйм"},
                { "mile",       "Миля"},

                { "kilobyte",  "Килобайт"},
                { "megabyte",  "Мегабайт"},
                { "gigabyte",  "Гигабайт"},
                { "kibibyte",  "Кибибайт"},
                { "mebibyte",  "Мебибайт"},
                { "gibibyte",  "Гибибайт"},
                { "byte",      "Байт"},

                { "kilogram",    "Килограмм"},
                { "gram",        "Грамм"},
                { "British ton", "Английская тонна"},
                { "American ton","Американская тонна"},
                { "pound",       "Фунт"},
                { "ounce",       "Унция"},

                { "gon",            "Град"},
                { "angular minute", "Угловая минута"},
                { "angular second", "Угловая секунда"},
                { "rad",            "Рад"},
                { "angular degree", "Угловой градус"},

                { "square meter",     "Квадратный метр"},
                { "square kilometer", "Квадратный километр"},
                { "hectare",          "Гектар"},
                { "acre",             "Акр"},
                { "square inch",      "Квадратный дюйм"},
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
