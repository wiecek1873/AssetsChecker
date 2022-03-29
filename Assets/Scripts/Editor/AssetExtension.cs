using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AssetsChecker
{
	public static class AssetExtension
	{
		public const string MATERIAL = ".mat";
		public const string PREFAB = ".prefab";

		public static List<string> Extensions()
		{
			List<string> knownExtensions = new List<string>();

			foreach (var fieldInfo in typeof(AssetExtension).GetFields())
				knownExtensions.Add((string)fieldInfo.GetValue(null));

			return knownExtensions;
		}

		public static List<string> ExtensionNames()
		{
			List<string> knownExtensionNames = new List<string>();

			foreach (var fieldInfo in typeof(AssetExtension).GetFields())
				knownExtensionNames.Add((string)fieldInfo.Name);

			return knownExtensionNames;
		}

		public static void CheckForKnownExtensions(List<string> extensions)
		{
			foreach (string extension in extensions)
			{
				if (!Extensions().Contains(extension))
					throw new System.Exception("Unknown extension: " + extension);
			}
		}

		public static Asset ExtensionToObject(string extension)
		{
			switch (extension)
			{
				case MATERIAL:
					return new Material();
				case PREFAB:
					return new Prefab();
				default:
					throw new System.Exception("Unknown extension: " + extension);
			}
		}
	}
}