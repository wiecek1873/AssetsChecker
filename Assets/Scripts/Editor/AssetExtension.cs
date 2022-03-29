using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AssetsChecker
{
	public static class AssetExtension
	{
		public static readonly string Material = ".mat";
		public static readonly string Prefab = ".prefab";

		public static List<string> AllExtensions()
		{
			List<string> knownExtensions = new List<string>();

			foreach (var fieldInfo in typeof(AssetExtension).GetFields())
				knownExtensions.Add((string)fieldInfo.GetValue(null));

			return knownExtensions;
		}

		public static void CheckForKnownExtensions(List<string> extensions)
		{
			foreach (string extension in extensions)
			{
				if (!AllExtensions().Contains(extension))
					throw new System.Exception("Unknown extension: " + extension);
			}
		}
	}
}