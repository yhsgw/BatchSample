

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
			// ファイル全体の操作
			this.FileCopy(formatConfigs);
			this.ConvertTextEncoding(formatConfigs);
			this.ConvertNewLineCode (formatConfigs);


			// 個別ファイルの操作
			this.FormatCorrection(formatDetailConfigs);
			this.FileSplit(formatDetailConfigs);
			this.EscapeCharacter(formatDetailConfigs);


			return 1;
		}

		/// <summary>
		/// ファイルコピー処理
		/// 同じファイルがある場合は、上書きします。
		/// </summary>
		/// <param name="configs">Configs.</param>
		private void FileCopy(List<FileFormatConfig> configs)
		{
			configs.ForEach((FileFormatConfig config) => {
				var files = System.IO.Directory.GetFiles(config.CopyFrom);
				foreach(var file in files)
				{
					var fileName = System.IO.Path.GetFileName(file);
					if(Regex.IsMatch(fileName, config.CopyFileName))
					{
						var from = System.IO.Path.Combine(config.CopyFrom,fileName);
						var to = System.IO.Path.Combine(config.CopyTo, fileName);
						System.IO.File.Copy(from, to, true);
						System.Console.WriteLine(string.Format("{0} を {1} へコピーしました。", from, to));
					}

				}
			});
		}

		/// <summary>
		/// テキストエンコードの変換
		/// </summary>
		/// <param name="configs">Configs.</param>
		private void ConvertTextEncoding(List<FileFormatConfig> configs)
		{
			var files = System.IO.Directory.GetFiles(configs[0].CopyTo);
			//var sourceEncodiong = System.Text.Encoding.GetEncoding (configs[0].CharCodeFrom);
			var distEncodiong = System.Text.Encoding.GetEncoding (configs[0].CharCodeTo);

			System.IO.FileStream fileStream = null;
			byte[] buffer = null;

			foreach (var file in files)
			{
				fileStream = new System.IO.FileStream (file, System.IO.FileMode.Open, System.IO.FileAccess.Read);
				buffer = new byte[fileStream.Length];
				fileStream.Read(buffer, 0, buffer.Length);
				fileStream.Close();

				System.IO.File.WriteAllText (file, configs[0].CharCodeFrom, distEncodiong);

			}

		}

		/// <summary>
		/// 改行コードの変換
		/// </summary>
		private void ConvertNewLineCode(List<FileFormatConfig> configs)
		{
			System.Console.WriteLine (@"ConvertNewLineCode");
		}

		/// <summary>
		/// ファイルフォーマット補正
		/// </summary>
		/// <param name="config">Config.</param>
		private void FormatCorrection(List<FileFormatDetailConfig> config)
		{
			System.Console.WriteLine (@"FormatCorrection");

		}

		/// <summary>
		/// ファイル分離
		/// </summary>
		/// <param name="config">Config.</param>
		private void FileSplit(List<FileFormatDetailConfig> config)
		{
			System.Console.WriteLine (@"FileSplit");

		}

		/// <summary>
		/// 文字列置換
		/// </summary>
		/// <param name="config">Config.</param>
		private void StringReplace(List<FileFormatDetailConfig> config)
		{
			System.Console.WriteLine (@"StringReplace");

		}

		/// <summary>
		/// エスケープ処理
		/// </summary>
		/// <param name="config">Config.</param>
		private void EscapeCharacter(List<FileFormatDetailConfig> config)
		{
			System.Console.WriteLine (@"EscapeCharacter");

		}

	}
}

