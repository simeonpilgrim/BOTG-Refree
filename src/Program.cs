using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOTG_Refree
{
	class Program
	{
		static void Main(string[] args)
		{
		}
	}

	public class Properties
	{
		Dictionary<string, string> values = new Dictionary<string, string>();
		public string getProperty(string name, string defaultValue)
		{
			string val;
			if (values.TryGetValue(name, out val))
				return val;
			return defaultValue;
		}

		public void Add(string name, string value)
		{
			values[name] = value;
		}
	}

	public class GameException : Exception
	{

	}

	public class LostException : GameException
	{
		public LostException(string msg, object x, object y)
		{

		}
		public LostException(string msg, object cmd)
		{

		}
	}

	public class InvalidInputException : GameException
	{
		public InvalidInputException(string expected, object a)
		{

		}
	}
}
