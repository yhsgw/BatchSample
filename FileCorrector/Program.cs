using System;
using BatchFramework;

namespace FileFromatConverter
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var app = new FileFormatConverterApplication ();

			System.Console.WriteLine(app.Execute ());
		}
	}
}
