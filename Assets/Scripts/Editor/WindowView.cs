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

			if (m_windowData.AssetDatabase.IsCreated)
			{
				m_scrollPosition = GUILayout.BeginScrollView(m_scrollPosition);

				foreach (var asset in m_windowData.AssetDatabase.GetAssets<Material>())
					asset.DrawView();

				GUILayout.EndScrollView();
			}

			GUI.enabled = true;
		}

		private void DrawInspectToolbar()
		{
			m_inspectToolbarIndex = GUILayout.Toolbar(m_inspectToolbarIndex, AssetExtension.ExtensionNames().ToArray());
		}
	}
}