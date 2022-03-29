using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace AssetsChecker
{
	public class WindowView : EditorWindow
	{
		private float m_myFloat = 1.23f;
		private int m_inspectToolbarIndex = 0;
		private Vector2 m_scrollPosition;

		WindowData m_windowData = new WindowData();

		[MenuItem("Window/AssetsChecker")]
		private static void ShowWindow()
		{
			GetWindow(typeof(WindowView));
		}

		private void OnGUI()
		{
			if (GUILayout.Button("Scan assets"))
				m_windowData.AssetDatabase.Create();

			if (!m_windowData.AssetDatabase.IsCreated)
				GUI.enabled = false;

			DrawInspectToolbar();

			m_scrollPosition = GUILayout.BeginScrollView(m_scrollPosition);

			foreach(var asset in m_windowData.AssetDatabase.GetAssets<Material>())
			{
				GUILayout.Label(asset.Path);
			}

			GUILayout.EndScrollView();

			GUI.enabled = true;
		}

		//private void DrawExtensionSection()
		//{
		//	GUILayout.Label("Chose files extensions to check", EditorStyles.boldLabel);

		//	GUILayout.BeginHorizontal();

		//	for(int i = 0; i < m_windowData.ChosenExtensions.Count; i++)
		//	{
		//		m_windowData.ChosenExtensions[i] = EditorGUILayout.Toggle(AssetExtension.ExtensionNames()[i], m_windowData.ChosenExtensions[i]);
		//	}

		//	GUILayout.EndHorizontal();
		//}

		private void DrawInspectToolbar()
		{
			m_inspectToolbarIndex = GUILayout.Toolbar(m_inspectToolbarIndex, AssetExtension.ExtensionNames().ToArray());
		}
	}
}