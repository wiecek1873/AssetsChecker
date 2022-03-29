using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AssetsChecker
{
	public abstract class Asset
	{
		public string Path;
		public string GUID;

		public abstract void DrawView();
		public abstract void LoadData();
	}
}