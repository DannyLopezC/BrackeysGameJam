using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInteraction : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        col.gameObject.GetComponent<PlayerInteraction>()?.PickBox(gameObject);
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        col.gameObject.GetComponent<PlayerInteraction>()?.DropBox();
    }
}