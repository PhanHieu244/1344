using System;
using UnityEngine;

namespace BzKovSoft.ObjectSlicer.Samples
{
	/// <summary>
	/// Asynchronously sliceable object
	/// </summary>
	public interface IBzSliceableNoRepeat
	{
		void Slice(Plane plane, int slicdId, Action<BzSliceTryResult> callBack);
	}
}
