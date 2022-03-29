using UnityEngine;
using System.Collections.Generic;
using System.IO;

namespace AssetsChecker
{
	public static class FileReader
	{
		private const int GUID_STRING_LENGTH = 6;

		public static List<string> FindAssetsOfType(string assetExtension, params string[] additionalExtensions)
		{
			List<string> extensions = new List<string>();
			extensions.Add(assetExtension);
			extensions.AddRange(additionalExtensions);

			AssetExtension.CheckForKnownExtensions(extensions);

			string rootFolder = Application.dataPath;

			List<string> assets = new List<string>();

			foreach (string extension in extensions)
				foreach (string assetPath in Directory.GetFiles(rootFolder, "*" + extension, SearchOption.AllDirectories))
					assets.Add(assetPath);

			return assets;
		}

		public static string GetAssetGUID(string assetPath)
		{
			string metaFilePath = assetPath + ".meta";

			try
			{
				//todo check if File.ReadLines is optimal
				foreach (string line in File.ReadLines(metaFilePath))
				{
					if (line.Contains("guid:"))
					{
						string guid = line.Substring(GUID_STRING_LENGTH, line.Length - GUID_STRING_LENGTH);
						return guid;
					}
				}
			}
			catch
			{
				Debug.LogError("Could not find meta file at this path: " + metaFilePath);
			}

			return string.Empty;
		}
	}
}