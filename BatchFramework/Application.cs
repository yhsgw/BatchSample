using System;

namespace BatchFramework
{
	public class Application
	{
		public Application ()
		{
		}

		public virtual int Run()
		{
			return 1;
		}

		public int Execute()
		{
			var result = 2;

			System.Console.WriteLine(@"バッチを開始します");

			result += this.Run();

			System.Console.WriteLine(@"バッチを終了します");

			return result;
		}

	}
}

