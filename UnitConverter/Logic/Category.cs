using System.Collections.Generic;

namespace UnitConverter.Logic
{
    public class Category
    {
        private string baseUnit;

        public string Name { get; }
        public List<string> UnitList { get; }
        public Dictionary<string, double> DictionaryOfCoefficients { get; }

        public Category(string name, Dictionary<string, double> dictionaryOfCoefficient, string baseUnit)
        {
            this.baseUnit = baseUnit;

            Name = name;

            DictionaryOfCoefficients = dictionaryOfCoefficient;
            DictionaryOfCoefficients.Add(baseUnit, 1);

            UnitList = new List<string>();
            foreach (var units in DictionaryOfCoefficients)
            {
                UnitList.Add(units.Key);
            }
        }

        public double Convert(double value, string unitFrom, string unitTo)
        {
            if (string.Equals(unitFrom, unitTo))
                return value;

            if (string.Equals(baseUnit, unitFrom))
                return value * DictionaryOfCoefficients[unitTo];

            if (string.Equals(baseUnit, unitTo))
                return value / DictionaryOfCoefficients[unitFrom];

            return value * DictionaryOfCoefficients[unitTo] / DictionaryOfCoefficients[unitFrom];
        }
    }
}
