using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using UnitConverter.Logic;

namespace UnitConverter
{
    public partial class FormMain : Form
    {
        private const string cValueMember = "Name";
        private const string cDisplayMember = "TranslateName";

        private List<Category> categories;
        private Category selectedCategory;
        private string selectedUnitFrom;
        private string selectedUnitTo;
        private double enteredValue;
        private Dictionary<string, string> categoriesTranslationEnToRu;
        private Dictionary<string, string> unitsTranslationEnToRu;

        public FormMain()
        {
            InitializeComponent();
            CreateCategories();

            var displayCategories = CreateTranslationsTable(categories, categoriesTranslationEnToRu);
            comboBoxСategory.ValueMember = cValueMember;
            comboBoxСategory.DisplayMember = cDisplayMember;
            comboBoxСategory.DataSource = displayCategories;
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxFrom.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out enteredValue))
            {
                selectedUnitFrom = (string)comboBoxUnitFrom.SelectedValue;

                if (checkBoxToAllUnits.Checked)
                {
                    string valueWithUnitFrom = $"{enteredValue} {unitsTranslationEnToRu[selectedUnitFrom]}";

                    StringBuilder sb = new StringBuilder();
                    foreach (var unitTo in selectedCategory.UnitList)
                    {
                        sb.AppendLine($"{selectedCategory.Convert(enteredValue, selectedUnitFrom, unitTo)} {unitsTranslationEnToRu[unitTo]}");
                        sb.AppendLine();
                    }
                    string valueWithUnitTo = sb.ToString();

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
            if (selectedCategory == null)
                return;

            var displayUnitsFrom = CreateTranslationsTable(selectedCategory.UnitList, unitsTranslationEnToRu);
            var displayUnitsTo = CreateTranslationsTable(selectedCategory.UnitList, unitsTranslationEnToRu);

            comboBoxUnitFrom.DataSource = displayUnitsFrom;
            comboBoxUnitFrom.ValueMember = cValueMember;
            comboBoxUnitFrom.DisplayMember = cDisplayMember;

            comboBoxUnitTo.DataSource = displayUnitsTo;
            comboBoxUnitTo.ValueMember = cValueMember;
            comboBoxUnitTo.DisplayMember = cDisplayMember;

            textBoxTo.Text = string.Empty;
        }
        private void checkBoxToAllUnits_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxToAllUnits.Checked)
            {
                comboBoxUnitTo.Enabled = false;
            }
            else
            {
                textBoxTo.Text = string.Empty;
                comboBoxUnitTo.Enabled = true;
            }
        }

        private void CreateCategories()
        {
            Dictionary<string, double> lenghtUnintsDictionary = new Dictionary<string, double>()
            {
                    { "kilometer",  1e-3 },
                    { "millimeter", 1e3 },
                    { "centimeter", 1e2 },
                    { "foot",       3.28084 },
                    { "yard",       1.09361 },
                    { "inch",       39.3701 },
                    { "mile",       1.0 / 1609 },
            };
            string lenghtBaseUnit = "meter";
            Category lenghtCategory = new Category("Lenght", lenghtUnintsDictionary, lenghtBaseUnit);

            Dictionary<string, double> informationVolumeUnintsDictionary = new Dictionary<string, double>()
            {
                    { "kilobyte",  1e-3 },
                    { "megabyte",  1e-6 },
                    { "gigabyte",  1e-9 },
                    { "kibibyte",  1 / Math.Pow(2, 10) },
                    { "mebibyte",  1 / Math.Pow(2, 20) },
                    { "gibibyte",  1 / Math.Pow(2, 30) }
            };
            string informationVolumeBaseUnit = "byte";
            Category informationVolumeCategory = new Category("Information Volume", informationVolumeUnintsDictionary, informationVolumeBaseUnit);

            Dictionary<string, double> massUnintsDictionary = new Dictionary<string, double>()
            {
                    { "gram",           1e3 },
                    { "British ton",    1.0 / 1016 },
                    { "American ton",   1.0 / 907 },
                    { "pound",          2.2046 },
                    { "ounce",          35.274 },
            };
            string massBaseUnit = "kilogram";
            Category massCategory = new Category("Mass", massUnintsDictionary, massBaseUnit);

            Dictionary<string, double> flatAngleUnintsDictionary = new Dictionary<string, double>()
            {
                    { "gon",            200.0 / 180 },
                    { "angular minute", 60 },
                    { "angular second", 3600 },
                    { "rad",            Math.PI / 180 },
            };
            string flatAngleBaseUnit = "angular degree";
            Category flatAngleCategory = new Category("Flat Angle", flatAngleUnintsDictionary, flatAngleBaseUnit);

            Dictionary<string, double> squareUnintsDictionary = new Dictionary<string, double>()
            {
                    { "square kilometer", 1e-6 },
                    { "hectare",          1e-4 },
                    { "acre",             1.0 / 4047 },
                    { "square inch",      1550 },
            };
            string squareBaseUnit = "square meter";
            Category squareCategory = new Category("Square", squareUnintsDictionary, squareBaseUnit);

            categories = new List<Category>
            {
                lenghtCategory,
                informationVolumeCategory,
                massCategory,
                flatAngleCategory,
                squareCategory,
            };

            CreateRuTranslations();
        }
        private void CreateRuTranslations()
        {
            categoriesTranslationEnToRu = new Dictionary<string, string>()
            {
                { "Lenght", "Длина" },
                { "Information Volume", "Объём информации" },
                { "Mass", "Масса" },
                { "Flat Angle", "Плоский угол" },
                { "Square", "Площадь" },
            };

            unitsTranslationEnToRu = new Dictionary<string, string>()
            {
                { "kilometer",  "Километр" },
                { "foot",       "Фут" },
                { "yard",       "Ярд" },
                { "meter",      "Метр" },
                { "millimeter", "Миллиметр" },
                { "centimeter", "Сантиметр" },
                { "inch",       "Дюйм" },
                { "mile",       "Миля" },

                { "kilobyte",  "Килобайт" },
                { "megabyte",  "Мегабайт" },
                { "gigabyte",  "Гигабайт" },
                { "kibibyte",  "Кибибайт" },
                { "mebibyte",  "Мебибайт" },
                { "gibibyte",  "Гибибайт" },
                { "byte",      "Байт" },

                { "kilogram",     "Килограмм" },
                { "gram",         "Грамм" },
                { "British ton",  "Английская тонна" },
                { "American ton", "Американская тонна" },
                { "pound",        "Фунт" },
                { "ounce",        "Унция" },

                { "gon",            "Град" },
                { "angular minute", "Угловая минута" },
                { "angular second", "Угловая секунда" },
                { "rad",            "Рад" },
                { "angular degree", "Угловой градус" },

                { "square meter",     "Квадратный метр" },
                { "square kilometer", "Квадратный километр" },
                { "hectare",          "Гектар" },
                { "acre",             "Акр" },
                { "square inch",      "Квадратный дюйм" },
            };
        }
        private DataTable CreateTranslationsTable(List<string> listForTranslate, Dictionary<string, string> dictionaryOfTranslations)
        {
            DataTable dataTable = new DataTable();
            DataColumn name = new DataColumn(cValueMember, typeof(string));
            DataColumn translateName = new DataColumn(cDisplayMember, typeof(string));

            dataTable.Columns.Add(name);
            dataTable.Columns.Add(translateName);

            foreach (var item in listForTranslate)
                dataTable.Rows.Add(item, dictionaryOfTranslations[item]);

            return dataTable;
        }
        private DataTable CreateTranslationsTable(List<Category> listForTranslate, Dictionary<string, string> dictionaryOfTranslations)
        {
            DataTable dataTable = new DataTable();
            DataColumn name = new DataColumn(cValueMember, typeof(Category));
            DataColumn translateName = new DataColumn(cDisplayMember, typeof(string));

            dataTable.Columns.Add(name);
            dataTable.Columns.Add(translateName);

            foreach (var item in listForTranslate)
                dataTable.Rows.Add(item, dictionaryOfTranslations[item.Name]);

            return dataTable;
        }
    }
}
