using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

//todo work on better class name
public class AssetsCheckerProjectExplorer
{
	public static string GetAssetGUID(string assetPath)
	{
		//todo check if File.ReadLines is optimal
		foreach (string line in File.ReadLines(Application.dataPath + "TestAssets/TestMaterial.mat.meta"))
		{
			Debug.Log(line);
		}

		return string.Empty;
	}
}
