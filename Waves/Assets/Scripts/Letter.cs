using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour
{
    public KeyCode key;
    public bool isJoker;

    public void SetKet(KeyCode key)
    {
        this.key = key;
        OnImageUpdated();
    }

	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public void OnImageUpdated()
    {

    }
}
