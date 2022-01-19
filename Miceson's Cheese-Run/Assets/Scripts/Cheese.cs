using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : MonoBehaviour
{
    private Renderer rend;

    [SerializeField]
    private Color colorToTurnTo = Color.white;
    void Start()
    {
        rend = GetComponent<Renderer>();
        Invoke("ChangeColor", 12);
    }

    public void ChangeColor()
    {
        rend.material.color = colorToTurnTo;
    }
}