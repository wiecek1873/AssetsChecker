using UnityEngine;
using System.Collections.Generic;
using System.IO;

namespace AssetsChecker
{
	public static class FileReader
	{
		private const int GUID_STRING_LENGTH = 6;

		public static List<Asset> GetAssets(string assetExtension, params string[] additionalExtensions)
		{
			List<string> extensions = new List<string>();
			extensions.Add(assetExtension);
			extensions.AddRange(additionalExtensions);

			string rootFolder = Application.dataPath;

			List<Asset> assets = new List<Asset>();

			foreach (string extension in extensions)
			{
				foreach (string assetPath in Directory.GetFiles(rootFolder, extension, SearchOption.AllDirectories))
				{
					assets.Add(new Asset
					{
						Path = assetPath,
						GUID = GetAssetGUID(assetPath)
					});
				}
			}

			foreach (var xd in assets)
				Debug.Log(xd.Path + " GUID: " + xd.GUID);

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