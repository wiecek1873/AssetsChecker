using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace AssetsChecker
{
	public class WindowView : EditorWindow
	{
		private float m_myFloat = 1.23f;

		WindowData m_windowData = new WindowData();

		[MenuItem("Window/AssetsChecker")]
		private static void ShowWindow()
		{
			GetWindow(typeof(WindowView));
		}

		private void OnGUI()
		{
			if (GUILayout.Button("Scan assets"))
			{
				m_windowData.AssetDatabase.Create();
			}

			DrawExtensionSection();

			GUI.enabled = false;
			m_myFloat = EditorGUILayout.Slider("Slider", m_myFloat, -3, 3);
			GUI.enabled = true;
		}

		private void DrawExtensionSection()
		{
			GUILayout.Label("Chose files extensions to check", EditorStyles.boldLabel);

			GUILayout.BeginHorizontal();

			for(int i = 0; i < m_windowData.ChosenExtensions.Count; i++)
			{
				m_windowData.ChosenExtensions[i] = EditorGUILayout.Toggle(AssetExtension.ExtensionNames()[i], m_windowData.ChosenExtensions[i]);
			}

			GUILayout.EndHorizontal();
		}
	}
}