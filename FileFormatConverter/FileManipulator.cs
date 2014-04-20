

namespace FileFromatConverter
{
	#region ----using----
	using System;
	using System.Collections.Generic;
	using System.Text.RegularExpressions;
	using BatchFramework;
	#endregion

	public class FileManipulator
	{
		public FileManipulator ()
		{
		}

		/// <summary>
		/// ファイルコピー処理
		/// 同じファイルがある場合は、上書きします。
		/// </summary>
		/// <param name="configs">Configs.</param>
		public void FileCopy(List<FileFormatConfig> configs)
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
		public void ConvertTextEncoding(List<FileFormatConfig> configs)
		{
			var files = System.IO.Directory.GetFiles(configs[0].CopyTo);
			var sourceEncodiong = System.Text.Encoding.GetEncoding (configs[0].CharCodeFrom);
			var distEncodiong = System.Text.Encoding.GetEncoding (configs[0].CharCodeTo);

			byte[] buffer = null;

			foreach (var file in files)
			{
				// ファイル読み込み
				buffer = ByteRead(file);

				// エンコーディング変換
				buffer = System.Text.Encoding.Convert(sourceEncodiong, distEncodiong, buffer);

				// ファイル書き込み
				ByteWrite(file, buffer);
			}

		}

		/// <summary>
		/// 改行コードの変換
		/// </summary>
		public void ConvertNewLineCode(List<FileFormatConfig> configs)
		{
			//var sourceEncodiong = System.Text.Encoding.GetEncoding (configs[0].CharCodeFrom);
			var distEncodiong = System.Text.Encoding.GetEncoding (configs[0].CharCodeTo);
			var files = System.IO.Directory.GetFiles(configs[0].CopyTo);

			foreach (var file in files)
			{
				// ファイル全体を読み込んで、文字列置換
				var fileContents = System.IO.File.ReadAllText (file, distEncodiong);
				fileContents = fileContents.Replace(configs [0].NewLineCodeFrom, configs [0].NewLineCodeTo);
				System.IO.File.WriteAllText(file, fileContents, distEncodiong);
			}


		}

		/// <summary>
		/// ファイルフォーマット補正
		/// </summary>
		/// <param name="config">Config.</param>
		public void FormatCorrection(List<FileFormatDetailConfig> configs)
		{
			System.Console.WriteLine (@"Call FormatCorrection");

		}

		/// <summary>
		/// ファイル分離
		/// </summary>
		/// <param name="config">Config.</param>
		public void FileSplit(List<FileFormatDetailConfig> configs)
		{
			System.Console.WriteLine (@"Call FileSplit");

		}

		/// <summary>
		/// 文字列置換
		/// </summary>
		/// <param name="config">Config.</param>
		public void StringReplace(List<FileFormatConfig> configs, List<FileFormatDetailConfig> detailConfigs)
		{
			System.Console.WriteLine (@"Call StringReplace");
			var distEncodiong = System.Text.Encoding.GetEncoding(configs[0].CharCodeTo);

			// 処理するファイルの種類だけ文字列置き換え定義を取得して、置換処理を行う
			detailConfigs.ForEach ((FileFormatDetailConfig config) => {
				var files = System.IO.Directory.GetFiles (configs[0].CopyTo);
				var replaceStringDict = new ReplaceStringConfigModel().Find();

				foreach (var file in files) {
					var fileName = System.IO.Path.GetFileName (file);
					if (Regex.IsMatch (fileName, config.FileName)) {
						// ファイル全体を読み込んで、文字列置換
						var fileContents = System.IO.File.ReadAllText (file, distEncodiong);

						foreach(KeyValuePair<string, string> pair in replaceStringDict[0].ReplaceStrings)
						{
							fileContents = fileContents.Replace (pair.Key, pair.Value);
						}

						System.IO.File.WriteAllText (file, fileContents, distEncodiong);
					}
				}
			});

		}

		/// <summary>
		/// エスケープ処理
		/// </summary>
		/// <param name="config">Config.</param>
		public void EscapeCharacter(List<FileFormatDetailConfig> configs)
		{
			System.Console.WriteLine (@"Call EscapeCharacter");

		}

		private byte[] ByteRead(string filePath)
		{
			System.IO.FileStream fileStream = null;
			byte[] buffer = null;

			// ファイル読み込み
			fileStream = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
			buffer = new byte[fileStream.Length];
			fileStream.Read(buffer, 0, buffer.Length);
			fileStream.Close();

			return buffer;
		}

		private void ByteWrite(string filePath, byte[] context)
		{
			// ファイル書き込み
			var distFileStream = new System.IO.FileStream(filePath,	System.IO.FileMode.Create, System.IO.FileAccess.Write);
			distFileStream.Write(context, 0, context.Length);
			distFileStream.Close();
		}
	}
}

