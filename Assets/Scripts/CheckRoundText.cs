using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class CheckRoundText : MonoBehaviour
    {

    bool isDestroy = true;

       public  List<GameObject> ListOBJ = new List<GameObject>();
    public GameObject CheckSpeed;
    public float _Scale;


    // Start is called before the first frame update
    void Start()
        {
        GetLevel();
    
        }
    void GetLevel()
    {
        string temp = "Level" + GameControl.Instance.Levelplay;
        List < GameObject > tempList = TextToObject.Instance.ConvertTextToOBJ(temp);
        for (int i = 0; i < tempList.Count; i++)
        {
            if (tempList[i].gameObject != null)
            {
                tempList[i].gameObject.transform.parent = this.transform;
                tempList[i].gameObject.transform.localScale = new Vector3(_Scale, _Scale, _Scale);
                tempList[i].gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
                tempList[i].gameObject.transform.localPosition = new Vector3(0 + i * 0.26f - tempList.Count * 0.13f, 0, 0);
                ListOBJ.Add(tempList[i].gameObject);
            }
        }
    }

        // Update is called once per frame
        void Update()
        {
     
        CheckDone();
        }
        void CheckDone()
        {
        bool _done = true;
        for (int i = 0; i < ListOBJ.Count; i++)
        {
            if (!ListOBJ[i].gameObject.name.Equals("Done"))
            {
                _done = false;
                break;
            }
        }
        if (_done && isDestroy)
        {
            isDestroy = false;
            StartCoroutine(DelayNExtRound());
    
        }
        }
    IEnumerator DelayNExtRound()
    { yield return new WaitForSeconds(1f);
        {
            GameControl.Instance.NextRound();
            CheckSpeed.SetActive(false);
            Destroy(this.gameObject, 1f);
        } }

 
}
