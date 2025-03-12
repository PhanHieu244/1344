using BzKovSoft.ObjectSlicer.Samples;
using UnityEngine;

/// <summary>
/// The script must be attached to a GameObject that have collider marked as a "IsTrigger".
/// </summary>
public class BzKnife : MonoBehaviour
{
	public static BzKnife Instance;
	public int SliceID { get; private set; }
	public Vector3 PosCam;
	public Vector3 HitPoin1 = new Vector3(0, 0, 0);
	public Vector3 HitPoin2 = new Vector3(0, 0, 0);
	Vector3 _pos;

    private void Awake()
    {
		Instance = this;
    }

    private void Update()
	{
		PosCam = Camera.main.transform.position;
		_pos = transform.position;
	}

	public void BeginNewSlice()
	{
		SliceID  += 1;
	}
	public void SetNewPos(Vector3 _newPos)
	{
		if (!_newPos.Equals(HitPoin1))
				{
			HitPoin2 = HitPoin1;
			HitPoin1 = _newPos;
		
		}
	}
	}
