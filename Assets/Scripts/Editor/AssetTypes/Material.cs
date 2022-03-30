using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace AssetsChecker
{
	public class Material : Asset
	{
		private Texture2D m_image;

		public override void DrawView()
		{
			GUILayout.BeginHorizontal();
			GUILayout.Label(m_image);
			GUILayout.Label(Path);
			GUILayout.EndHorizontal();
		}

		public override void LoadData()
		{
			string path = Path.Remove(0, Application.dataPath.Length - 6);
			UnityEngine.Material material = (UnityEngine.Material)UnityEditor.AssetDatabase.LoadAssetAtPath(path, typeof(UnityEngine.Material));
			m_image = (Texture2D)AssetPreview.GetAssetPreview(material);
		}
	}
}