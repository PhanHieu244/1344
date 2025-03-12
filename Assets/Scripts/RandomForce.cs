using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomForce : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
      Rigidbody Rig =  this.GetComponent<Rigidbody>();
        float ranX = Random.Range(-200,200);
          float ranY = Random.Range(100,200);
          float ranZ = Random.Range(-200,200);
        Rig.AddForce(10*new Vector3(ranX, ranY, ranZ));

    }
}
