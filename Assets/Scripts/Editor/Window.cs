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

		[MenuItem("Window/AssetsChecker")]
		private static void ShowWindow()
		{
			GetWindow(typeof(Window));
		}

		private void OnGUI()
		{
			if (GUILayout.Button("Find textures"))
			{
				Debug.Log(FileReader.GetAssets("*.mat"));
			}

			GUILayout.Label("Base Settings", EditorStyles.boldLabel);
			m_myString = EditorGUILayout.TextField("Text Field", m_myString);

			m_groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", m_groupEnabled);
			m_myBool = EditorGUILayout.Toggle("Toggle", m_myBool);
			m_myFloat = EditorGUILayout.Slider("Slider", m_myFloat, -3, 3);
			EditorGUILayout.EndToggleGroup();
		}
	}
}