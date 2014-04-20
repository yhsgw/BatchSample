using System;
using System.Collections.Generic;

namespace FileFromatConverter
{
	public class FileFormatDetailConfigModel
	{
		public FileFormatDetailConfigModel ()
		{
		}

		public List<FileFormatDetailConfig> Find()
		{
			var result = new List<FileFormatDetailConfig> ();
			result.Add(
				new FileFormatDetailConfig {
					FileId = @"00000001",
					EscapeChar = @"\",
					ItemCount = 5,
					IdItemInfo = @"ID001",
					IdItemColumn = 2,
					FileName = @"splitFile1.log"
				}
			);
			result.Add(
				new FileFormatDetailConfig {
					FileId = @"00000002",
					EscapeChar = @"\",
					ItemCount = 4,
					IdItemInfo = @"ID002",
					IdItemColumn = 2,
					FileName = @"TestFile_00002.log"
				}
			);

			return result;

		}
	}
}

