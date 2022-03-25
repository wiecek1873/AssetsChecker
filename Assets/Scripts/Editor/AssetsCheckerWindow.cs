using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AssetsCheckerWindow : EditorWindow
{
	[MenuItem("Window/AssetsChecker")]
	private static void ShowWindow()
	{
		EditorWindow.GetWindow(typeof(AssetsCheckerWindow));
	}
}
