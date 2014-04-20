

namespace FileFromatConverter
{
	#region ----using----
	using System;
	using System.Collections.Generic;
	using System.Text.RegularExpressions;
	using BatchFramework;
	#endregion

	public class FileFormatConverterApplication : BatchFramework.Application
	{
		private List<FileFormatConfig> formatConfigs;
		private List<FileFormatDetailConfig> formatDetailConfigs;

		public FileFormatConverterApplication (): base()
		{
			formatConfigs = new FileFormatConfigModel().Find();
			formatDetailConfigs = new FileFormatDetailConfigModel().Find ();

		}

		public override int Run()
		{
			var manipulator = new FileManipulator();

			// ファイル全体の操作
			manipulator.FileCopy(formatConfigs);
			manipulator.ConvertTextEncoding(formatConfigs);
			manipulator.ConvertNewLineCode (formatConfigs);


			// 個別ファイルの操作
			manipulator.FormatCorrection(formatDetailConfigs);
			manipulator.FileSplit(formatDetailConfigs);
			manipulator.StringReplace(formatConfigs, formatDetailConfigs);
			manipulator.EscapeCharacter(formatDetailConfigs);


			return 1;
		}



	}
}

