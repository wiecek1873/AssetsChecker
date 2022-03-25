using UnityEngine;
using System.Collections.Generic;
using System.IO;

//todo work on better class name
public static class AssetsCheckerProjectExplorer
{
	private const int GUID_STRING_LENGTH = 6;

	private static List<string> GetAssets(string assetExtension, params string[] additionalExtensions)
	{
		List<string> extensions = new List<string>();
		extensions.Add(assetExtension);
		extensions.AddRange(additionalExtensions);

		string rootFolder = Application.dataPath;

		List<AssetsCheckerAsset> assets = new List<AssetsCheckerAsset>();

		foreach (string extension in extensions)
		{
			foreach (string assetPath in Directory.GetFiles(rootFolder, extension, SearchOption.AllDirectories))
			{
				assets.Add(new AssetsCheckerAsset
				{
					Path = assetPath
				});
			}
		}

		//foreach (var xd in assets)
		//	Debug.Log(xd.Path);

		return new List<string>();
	}

	public static string GetAssetGUID(string assetPath)
	{
		GetAssets("*.png", new string[] { "*.mat", "*.prefab" });
		//string metaFilePath = Application.dataPath + assetPath + ".meta";

		//try
		//{
		//	//todo check if File.ReadLines is optimal
		//	foreach (string line in File.ReadLines(metaFilePath))
		//	{
		//		if (line.Contains("guid:"))
		//		{
		//			string guid = line.Substring(GUID_STRING_LENGTH, line.Length - GUID_STRING_LENGTH);
		//			return guid;
		//		}
		//	}
		//}
		//catch
		//{
		//	Debug.LogError("Could not find meta file at this path: " + metaFilePath);
		//}

		return string.Empty;
	}
}
