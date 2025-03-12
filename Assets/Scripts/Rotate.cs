using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
 public    bool isZ;
 public   bool isY;
  public  bool isX;
   public float speed ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = this.transform.eulerAngles;
        if (isX)
        {
            temp.x += speed * Time.deltaTime;
        }
        if (isY)
        {
            temp.y += speed * Time.deltaTime;
        }
        if (isZ)
        {
            temp.z += speed * Time.deltaTime;
        }
        this.transform.localEulerAngles = temp;
    }
}
