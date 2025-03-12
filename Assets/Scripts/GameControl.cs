using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameControl : MonoBehaviour
{
    public GameObject ParentCame2;
    public Transform Cam1;
    public Button btPlay;

    public static GameControl Instance;
    public GameObject RoundDefault;
    public List<GameObject> ListPrefab = new List<GameObject>();
    public List<GameObject> ListRound = new List<GameObject>();
    public GameObject RoundText;
    public GameObject EFShoot;
    public GameObject EFWin;
    int tempRound = 0;
    int numRound = 20;
    public bool isTouch = false;

    public int Levelplay = 1;
    public bool isPlay = false;

    public Text txtLevel;
    public Text txtEndGame;
    public Button btReload;
    private void Awake()
    {
        Instance = this;
        btPlay.onClick.AddListener(ClickStartGame);
    }

    // Start is called before the first frame update
    void Start()
    {
        AddnewRound();
        GetLevel();
        txtEndGame.gameObject.SetActive(false);
        btReload.onClick.AddListener(Reload);
    }

    void ClickStartGame()
    {
        //isPlay = true;
        //ParentCame2.SetActive(false);
        MoveRotateCame();
        btPlay.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isTouch = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isTouch = false;
        }
    }
    void AddnewRound()
    {
        if (ListPrefab.Count > 0) {
            for (int i = 0; i < numRound; i++)
            {


                if (i < 5)
                {
                    GameObject _round = GameObject.Instantiate(RoundDefault, null);
                    _round.active = false;
                    _round.transform.parent = this.transform;
                    _round.transform.localPosition = new Vector3(0, 0, 14 * i + 30);
                    ListRound.Add(_round);
                }
                else
                {
                    if (i < numRound - 1)
                    {
                        int tempid = Random.Range(0, ListPrefab.Count);
                        GameObject _round = GameObject.Instantiate(ListPrefab[tempid], null);
                        _round.active = false;
                        _round.transform.parent = this.transform;
                        _round.transform.localPosition = new Vector3(0, 0, 14 * i + 30);
                        ListRound.Add(_round);
                    }
                    else
                    {
                        GameObject _round = GameObject.Instantiate(RoundText, null);
                        _round.active = false;
                        _round.transform.parent = this.transform;
                        _round.transform.localPosition = new Vector3(0, 0, 14 * i + 30);
                        ListRound.Add(_round);
                    }
                }
               
            }
        }
    }
    void GetLevel()
    {
        Levelplay = PlayerPrefs.GetInt(KeySave.Levelplay, 1);
        txtLevel.text = "Level " + Levelplay;
    }
    public void MoveRotateCame()
    {
        ParentCame2.transform.parent = null;
        ParentCame2.transform.DORotate(new Vector3(0, 0, 0), .5f);
        ParentCame2.transform.DOMove(Cam1.transform.position, .5f);
        StartCoroutine(delayMove());
    }
    IEnumerator delayMove()
    {
        yield return new WaitForSeconds(.5f);
        {
            ParentCame2.gameObject.SetActive(false);
            isPlay = true;
            NextRound();
        }
    }
    void CheckRound()
    {

    }
    public void NextRound()
    {
        if (tempRound >= 0 && tempRound < ListRound.Count)
        {
            ListRound[tempRound].SetActive(true);
            AddEFShoot(ListRound[tempRound].transform.position);
            tempRound += 1;
            SoundControl.Instance.PlayShoot();
        }

    }
    public void MissionFail()
    {
        if (isPlay)
        {
            Debug.Log("Fail");
            isPlay = false;
            SoundControl.Instance.PlayFail();
            txtEndGame.gameObject.SetActive(true);
            txtEndGame.text = "Mission Fail !";
        }
    }
    public void MissionComplete()
    {
        if (isPlay) {
            isPlay = false;
            Debug.Log("Win");
            Levelplay += 1;
            PlayerPrefs.SetInt(KeySave.Levelplay, Levelplay);
            PlayerPrefs.Save();
            GetLevel();
            SoundControl.Instance.PlayWin();
            txtEndGame.gameObject.SetActive(true);
            txtEndGame.text = "Mission Complete !";
        }
    }
    public void AddEFShoot(Vector3 _Pos)
    {
        GameObject _ef = GameObject.Instantiate(EFShoot, null);
        _ef.transform.position = _Pos;

    }
    public void AddEFWin(Vector3 _Pos)
    {
        GameObject _ef = GameObject.Instantiate(EFWin, null);
        _ef.transform.position = _Pos;

    } public void Reload()
    {
        StartCoroutine(delayBack());
        //AdsManager.Instance.ShowFull();

       
    }
    IEnumerator delayBack()
    {
        yield return new WaitForSeconds(.5f);
        {
            string temp = Application.loadedLevelName;
            Application.LoadLevel(temp);
        }
    }
}
