using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AssetsChecker
{
	public class WindowData
	{
		public List<bool> ChosenExtensions;
		
		private AssetDatabase m_assetDatabase;

		public AssetDatabase AssetDatabase => m_assetDatabase;

		public WindowData()
		{
			InitializeAssetDatabase();
			InitializeChosenExtensions();
		}

		private void InitializeAssetDatabase()
		{
			m_assetDatabase = new AssetDatabase();
		}

		private void InitializeChosenExtensions()
		{
			ChosenExtensions = new List<bool>();
		
			for (int i = 0; i < AssetExtension.Extensions().Count; i++)
				ChosenExtensions.Add(false);
		}
	}
}