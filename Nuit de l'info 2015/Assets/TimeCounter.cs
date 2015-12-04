using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour {

    Text _count;
    int _tempsRestants;
    float _interval;


    void Awake()
    {
        _count = GetComponent<Text>();
        _tempsRestants = 31;
        _interval = 6f;
    }

	public void BeginCounter()
    {
        UpdateTime();
    }

    void UpdateTime()
    {
        if (_tempsRestants == 1)
        {
            Application.LoadLevel("HappyEnd");
            return;
        }

        _tempsRestants--;
        _count.text = _tempsRestants.ToString();
        Invoke("UpdateTime", _interval);
    }
	
}
