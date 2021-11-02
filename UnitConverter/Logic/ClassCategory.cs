using System;
using System.Collections.Generic;

namespace UnitConverter.Logic
{
    public class Category
	{
		public string baseUnit;

		public string Name{ get; }

		public List<string> UnitList { get;  }
 		     
		public Dictionary<string, double> DictionaryOfCoefficient { get; }

		public Category(string name, Dictionary<string, double> dictionaryOfCoefficient, string baseUnit)
        {
			Name = name;

			DictionaryOfCoefficient = dictionaryOfCoefficient;

			this.baseUnit = baseUnit;

			DictionaryOfCoefficient.Add(baseUnit, 1);

			UnitList = new List<string>();
			foreach (var units in DictionaryOfCoefficient)
			{ UnitList.Add(units.Key); }

		}
		
		public double Convert(double value, string unitfrom, string unitto)
		{
			if (String.Equals(unitfrom, unitto))
			{
				return value;
			}
            else 
			{
				if (String.Equals(baseUnit, unitfrom))
				{
					return value * DictionaryOfCoefficient[unitto];
				}
				else
                {
					if (String.Equals(baseUnit, unitto))
					{ 
						return value/ DictionaryOfCoefficient[unitfrom];
					}
					else
                    {
						return value * DictionaryOfCoefficient[unitfrom] / DictionaryOfCoefficient[unitto];
					}
                }
			}
		}
    }
}
