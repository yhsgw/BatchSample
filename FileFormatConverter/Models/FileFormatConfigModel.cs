using System;
using System.Collections.Generic;

namespace FileFromatConverter
{
	public class FileFormatConfigModel
	{
		public FileFormatConfigModel ()
		{
		}


		public List<FileFormatConfig> Find()
		{
			var result = new List<FileFormatConfig> ();
			result.Add(
				new FileFormatConfig {
					FileId = @"00000000",
					CopyFrom = @"/var/batchTestDir/extracted",
					CopyTo = @"/var/batchTestDir/FormatConvWorking",
					CopyFileName = @"TestFile_.*\.log",
					CharCodeFrom = @"Shift_JIS",
					CharCodeTo = @"UTF-8",
					NewLineCodeFrom = @"{CR}{LF}",
					NewLineCodeTo = @"{LF}",
					Splitter = @"\t"
				}
			);

			return result;

		}
	}
}

