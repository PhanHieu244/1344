
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;
/// <summary>
/// This script will invoke slice method of IBzSliceableNoRepeat interface if knife slices this GameObject.
/// The script must be attached to a GameObject that have rigidbody on it and
/// IBzSliceable implementation in one of its parent.
/// </summary>
[DisallowMultipleComponent]
public class KnifeSlice : MonoBehaviour
{

	public bool isSlice = true;

[HideInInspector]	public OBJSlice _sliceableAsync;

	void Start()
	{
		_sliceableAsync = GetComponentInParent<OBJSlice>();
		
	}


	private void OnMouseEnter()
	{
		if (GameControl.Instance.isTouch)
		{
			Debug.Log("OnMouseEnter" + this.gameObject.name);
			StartCoroutine(Slice(BzKnife.Instance));
		}
	}


	private IEnumerator Slice(BzKnife knife)
	{

		yield return new WaitForSeconds(.001f);
		{
			knife.BeginNewSlice();

			Plane plane = new Plane(knife.HitPoin1, knife.HitPoin2, knife.PosCam);
			//plane = new Plane(new Vector3(-0.2f, 1, -0.1f), 0.4f);
			Debug.Log("Call Slice:" + knife.SliceID + " Plane:" + plane);
			_sliceableAsync.Slice(plane, knife.SliceID, null);

		}
	}


}
