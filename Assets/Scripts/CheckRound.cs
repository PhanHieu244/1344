using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class CheckRound : MonoBehaviour
    {
 
    public List<GameObject> ListFruits = new List<GameObject>();
    bool isDestroy = true;

         List<GameObject> ListOBJ = new List<GameObject>();
    public List<Transform> ListPos = new List<Transform>();
    public GameObject CheckSpeed;
    public float _Scale;


    // Start is called before the first frame update
    void Start()
        {

        int rank = Random.RandomRange(0,ListFruits.Count);
        
            for (int i = 0; i < ListPos.Count; i++)
            {
            GameObject _f = RandomFruits(rank);
                ListOBJ.Add(_f);
            _f.transform.parent = this.transform;
            _f.transform.position = ListPos[i].position;
            _f.transform.localScale = new Vector3(_Scale, _Scale, _Scale);
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

    GameObject RandomFruits()
    {
        if (ListFruits.Count > 0)
        {
            int temp = Random.Range(0, ListFruits.Count);
            GameObject _Fruits = GameObject.Instantiate(ListFruits[temp], null);
      
            return _Fruits;
        }
        else
            return null;
    }
    GameObject RandomFruits(int _id)
    {
        if (_id >= 0 && _id <ListFruits.Count )
        {

            GameObject _Fruits = GameObject.Instantiate(ListFruits[_id], null);

            return _Fruits;
        }
        else
            return null;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("CheckRound");
    }
}
