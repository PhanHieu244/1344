using BzKovSoft.ObjectSlicer.Samples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollControl : MonoBehaviour
{
    public List<Rigidbody> ListRig = new List<Rigidbody>();
    public List<Collider> ListColl = new List<Collider>();

    private void Awake()
    {
        for (int i = 0; i < ListRig.Count; i++)
        {
            ListRig[i].isKinematic = true;
        }
        for (int i = 0; i < ListColl.Count; i++)
        {
          //  ListColl[i].enabled = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //var rigids = GetComponentsInChildren<Rigidbody>();

        //for (int i = 0; i < rigids.Length; i++)
        //{
        //    var rigid = rigids[i];
        //    var go = rigid.gameObject;

        //    if (go == gameObject)
        //        continue;

        //    if (go.GetComponent<KnifeSliceableAsync>() != null)
        //        continue;

        //    go.AddComponent<KnifeSliceableAsync>();
        //}

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
