using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseScale : MonoBehaviour
{
    public void pointerEnter()
    {
        transform.localScale = new Vector2(2f, 2f);

    }

    public void pointerExit()
    {
        transform.localScale = new Vector2(1f, 1f);

    }
}
