using UnityEngine;
using System.IO;

//todo work on better class name
public static class AssetsCheckerProjectExplorer
{
	private const int GUID_STRING_LENGTH = 6;

	public static string GetAssetGUID(string assetPath)
	{
		string metaFilePath = Application.dataPath + assetPath + ".meta";

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
