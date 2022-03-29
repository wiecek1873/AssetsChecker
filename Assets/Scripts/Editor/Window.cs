using UnityEngine;
using UnityEditor;

namespace AssetsChecker
{
	public class Window : EditorWindow
	{
		private string m_myString = "Hello World";
		private bool m_groupEnabled;
		private bool m_myBool = true;
		private float m_myFloat = 1.23f;

		AssetDatabase m_assetDatabase;

		[MenuItem("Window/AssetsChecker")]
		private static void ShowWindow()
		{
			GetWindow(typeof(Window));
		}

		private void OnGUI()
		{
			if (GUILayout.Button("Find textures"))
			{
				m_assetDatabase = new AssetDatabase();
				m_assetDatabase.CreateDatabase();
			}

			if(m_assetDatabase == null)
				GUI.enabled = false;

			GUILayout.Label("Base Settings", EditorStyles.boldLabel);
			m_myString = EditorGUILayout.TextField("Text Field", m_myString);

			GUILayout.BeginHorizontal();
			foreach(string extension in AssetExtension.ExtensionNames())
			{
				m_myBool = EditorGUILayout.Toggle(extension, m_myBool);
			}
			GUILayout.EndHorizontal();

			m_myFloat = EditorGUILayout.Slider("Slider", m_myFloat, -3, 3);
			GUI.enabled = true;
		}
	}
}