using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AssetsChecker
{
	public class AssetDatabase
	{
		private List<Asset> m_assets;

		public bool IsCreated => m_assets != null;

		public void Create()
		{
			m_assets = new List<Asset>();
			List<string> assetPaths = new List<string>();
			assetPaths.AddRange(FileReader.FindAssetsOfType(AssetExtension.Extensions().ToArray()));

			foreach(string assetPath in assetPaths)
			{
				m_assets.Add(new Asset
				{
					Path = assetPath,
					GUID = FileReader.GetAssetGUID(assetPath)
				});
			}
			WriteAssetsToConsole();
		}

		private void WriteAssetsToConsole()
		{
			foreach (var asset in m_assets)
				Debug.Log(asset.Path + "\n GUID: " + asset.GUID);
		}
	}
}