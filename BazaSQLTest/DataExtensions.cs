using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace BazaSQLTest
{
	public static class DataExtensions
	{
		public static string GetSafeString(this MySqlDataReader reader, int colIndex)
		{
			if (!reader.IsDBNull(colIndex))
				return reader[colIndex].ToString();
			else
				return string.Empty;
		}
	}
}
