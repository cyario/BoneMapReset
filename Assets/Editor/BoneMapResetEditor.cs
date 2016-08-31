using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(BoneMapReset))]
public class BoneMapResetEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		BoneMapReset bmr = (BoneMapReset)target;

		if ( GUILayout.Button("Reset Bone Map") )
		{
			bmr.Convert();
		}
	}
}