using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl : MonoBehaviour
{
    public BzKnife KnifeControl;
    public GameObject EFTouch;
    bool isDrag = false;
    public Camera cam;
    [SerializeField] private LayerMask LayerSwipe;
    [SerializeField] private LayerMask LayerCut;
    [SerializeField] private LayerMask LayerSpeed;

    float speedCut = 0.1f;
    public float SpeedMoveCame = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameControl.Instance.isPlay)
        {
            cam.transform.Translate(new Vector3(0, 0, 1) * SpeedMoveCame * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                isDrag = true;
                EFTouch.SetActive(true);
               

                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                Debug.Log("Click Pos:"+ Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, LayerSwipe))
                {
                    Debug.Log("Shutdown");
                    EFTouch.transform.position = raycastHit.point;
                    KnifeControl.HitPoin1 = raycastHit.point;
                }

            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                isDrag = false;
                EFTouch.SetActive(false);

            }
            if (isDrag)
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, LayerSwipe))
                {

                    EFTouch.transform.position = Vector3.Lerp(EFTouch.transform.position, raycastHit.point, 30f * Time.deltaTime);
                    KnifeControl.SetNewPos(raycastHit.point);
                    Debug.DrawLine(cam.gameObject.transform.position, KnifeControl.HitPoin1);
                    Debug.DrawLine(cam.gameObject.transform.position, KnifeControl.HitPoin2);
                }


            }

            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime);
            }


        }
    }
    private void FixedUpdate()
    {
        CheckSpeed();
        //Ray rayCut = cam.ScreenPointToRay(Input.mousePosition);
        //if (Physics.Raycast(rayCut, out RaycastHit raycastHit2, float.MaxValue, LayerCut))
        //{

        //    raycastHit2.collider.gameObject.GetComponent<KnifeSliceableAsync>().CutIt(KnifeControl);
        //}
    }
    void CheckSpeed()
    {

        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position + new Vector3(0, 0, 0), Vector3.forward, 6f, LayerSpeed))
        {
            SpeedMoveCame = 0.5f;
        }
        else
        {
            SpeedMoveCame = 50f;
        }
    }
}
