using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMod : MonoBehaviour
{
    public Texture2D NormalIcon;
    public Texture2D TapIcon;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(NormalIcon, Vector2.zero, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(0)){StartCoroutine("Tapped");}
    }

    IEnumerator Tapped()
    {
        Cursor.SetCursor(TapIcon, Vector2.zero, CursorMode.ForceSoftware);
        yield return new WaitForSeconds(0.2f);
        Cursor.SetCursor(NormalIcon, Vector2.zero, CursorMode.ForceSoftware);
    }

}
