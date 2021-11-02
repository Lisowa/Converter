using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Logic
{
	public class Category
	{
		//private List<string> unitList = new List<string>();
		public string Name{ get; }
		public List<string> UnitList { get;  }
       /* {
            get
            {
                return unitList;
            }
            set
            {
                unitList = value;
            }
        }*/
		     
		public string baseUnit;
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

		//private Dictionary<string, double> dictionaryOfCoefficient = new Dictionary<string, double>();
		public Dictionary<string, double> DictionaryOfCoefficient { get;  }

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
