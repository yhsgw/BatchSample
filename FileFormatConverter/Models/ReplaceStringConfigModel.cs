using System;
using System.Collections.Generic;

namespace FileFromatConverter
{
	public class ReplaceStringConfigModel
	{
		public ReplaceStringConfigModel ()
		{
		}

		public List<ReplaceStringConfig> Find()
		{
			var result = new List<ReplaceStringConfig> ();

			result.Add(new ReplaceStringConfig(){

				ReplaceStrings = new Dictionary<string, string> (){
					{"rep1","0001"},
					{"rep2","0002"},
					{"rep3","0003"},
					{"rep4","0004"},
					{"rep5","0005"}
				}
			});
			return result;
		}
	}
}

