using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEndGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "OBJ")
        {
            Debug.Log("End Game");
            GameControl.Instance.MissionFail();
        }
        else
        {
            if (other.tag == "CheckWin")
            {
                Debug.Log("Win");
                GameControl.Instance.MissionComplete();
                Vector3 temp = new Vector3(0,0,0);
                temp.z = other.transform.position.z + 10f;
                GameControl.Instance.AddEFWin(temp);
            }
        }

    }
}
