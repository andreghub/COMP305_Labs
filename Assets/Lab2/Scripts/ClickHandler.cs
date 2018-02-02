using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{

    public GameObject AttachedObject;
    public Sprite Sprite;

    private SpriteRenderer sRend;

    // Use this for initialization
    void Start()
    {
        sRend = AttachedObject.GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        sRend.sprite = Sprite;
    }
}
