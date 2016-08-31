using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class BoneMapReset : MonoBehaviour
{
	public GameObject original;

	public void Convert()
	{
		SkinnedMeshRenderer[] skinnedMeshs = this.GetComponentsInChildren<SkinnedMeshRenderer>();

		foreach ( var s in skinnedMeshs )
		{
			Reset( s.GetComponent<SkinnedMeshRenderer>(), s.name );
		}
	}

	void Reset( SkinnedMeshRenderer targetRenderer, string name )
	{
		SkinnedMeshRenderer originalRenderer = getChildGameObject( original, name ).GetComponent<SkinnedMeshRenderer>();

		if (targetRenderer == null || originalRenderer == null ) return;

		Transform[] newBones = new Transform[targetRenderer.bones.Length];

		for ( int i = 0; i < originalRenderer.bones.Length; i++ )
		{
			for ( int j = 0; j < targetRenderer.bones.Length; j++ )
			{
				if ( targetRenderer.bones[j].name == originalRenderer.bones[i].name )
				{
					newBones[i] = targetRenderer.bones[j];
					continue;
				}
			}
		}

		targetRenderer.sharedMesh = originalRenderer.sharedMesh;
		targetRenderer.bones = newBones;		
	}

	GameObject getChildGameObject(GameObject fromGameObject, string withName)
	{
		Transform[] ts = fromGameObject.transform.GetComponentsInChildren<Transform>();
		foreach (Transform t in ts) if (t.gameObject.name == withName) return t.gameObject;
		return null;
	}
}