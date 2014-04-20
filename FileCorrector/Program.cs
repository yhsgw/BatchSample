using System;
using BatchFramework;

namespace FileCorrector
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var app = new FileCorrectorApplication ();

			System.Console.WriteLine(app.Execute ());
		}
	}
}
