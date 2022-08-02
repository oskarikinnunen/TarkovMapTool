using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TarkovMap
{
	internal static class Logger
	{
		public static void WriteLog(string logmessage)
		{
			File.AppendAllText(@"logs\log.txt", logmessage);
		}

		public static void WriteExceptionLog(Exception ex)
		{
			string errorstring = ex.ToString();
			File.AppendAllText(@"logs\log.txt", "EXCEPTION:" + errorstring);
		}
	}
}
