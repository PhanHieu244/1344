using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextToObject : MonoBehaviour
{
    public static TextToObject Instance;
    public List<GameObject> listAlphabet = new List<GameObject>();
    public string name = "Hello";
    public List<string> ListText = new List<string>();
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update

 
 public   List<GameObject> ConvertTextToOBJ(string _name)
    {
        name = _name.ToUpper();
        List<GameObject> ListT = new List<GameObject>();
        for (int i = 0; i < name.Length; i++)
        {
          GameObject _txt =  GetChar(name[i]);
            ListT.Add(_txt);

        }
        return ListT;
    
    }
    GameObject GetChar(char _char)
    {
        string _name = "alp_" + _char;
        for (int i = 0; i < listAlphabet.Count; i++)
        {
            if (_name.Equals(listAlphabet[i].gameObject.name))
            {
                return GameObject.Instantiate( listAlphabet[i].gameObject);
            }

        }
        return null;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
