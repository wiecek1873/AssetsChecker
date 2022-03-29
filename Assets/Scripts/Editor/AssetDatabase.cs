using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

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

			foreach (string assetPath in assetPaths)
			{
				Asset asset = AssetExtension.ExtensionToObject(Path.GetExtension(assetPath));
				asset.Path = assetPath;
				asset.GUID = FileReader.GetAssetGUID(assetPath);
				m_assets.Add(asset);
			}

			WriteAssetsToConsole();
		}

		public List<T> GetAssets<T>() where T : Asset
		{
			return m_assets.OfType<T>().ToList();
		}

		private void WriteAssetsToConsole()
		{
			foreach (var asset in m_assets)
				Debug.Log(asset.Path + "\n GUID: " + asset.GUID);
		}
	}
}