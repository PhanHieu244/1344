using BzKovSoft.ObjectSlicer.EventHandlers;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using BzKovSoft.ObjectSlicer;

[DisallowMultipleComponent]
public class DoneSlice : MonoBehaviour, IBzObjectSlicedEvent
{
	public void ObjectSliced(GameObject original, GameObject resultNeg, GameObject resultPos)
	{
		// we need to wait one fram to allow destroyed component to be destroyed.
		StartCoroutine(NextFrame(original, resultNeg, resultPos));
		//	Debug.Log("AddForce");
	}

	private IEnumerator NextFrame(GameObject original, GameObject resultNeg, GameObject resultPos)
	{
		yield return null;

		var oRigid = original.GetComponent<Rigidbody>();
		var aRigid = resultNeg.GetComponent<Rigidbody>();
		var bRigid = resultPos.GetComponent<Rigidbody>();

		if (oRigid == null)
			yield break;

		oRigid.isKinematic = false;
		aRigid.isKinematic = false;
		bRigid.isKinematic = false;

		oRigid.gameObject.name = "Done";
		oRigid.gameObject.tag = "Untagged";
		aRigid.gameObject.tag = "Untagged";
		bRigid.gameObject.tag = "Untagged";

		aRigid.angularVelocity = oRigid.angularVelocity;
		bRigid.angularVelocity = oRigid.angularVelocity;
		aRigid.velocity = oRigid.velocity;
		bRigid.velocity = oRigid.velocity;
		float randXL = Random.Range(-80, -50);
		float randYL = Random.Range(50, 80);
		float randXR = Random.Range(50, 80);
		float randYR = Random.Range(50, 80);
		aRigid.AddForce(new Vector3(randXL, randYL, 100));
		bRigid.AddForce(new Vector3(randXR, randYR, 100));
		SoundControl.Instance.PlayHit();

	}
}

