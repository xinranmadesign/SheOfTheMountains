using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DragNDrop : MonoBehaviour
{
    [SerializeField]
    private bool isHeld;

    private Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector3.forward, Mathf.Infinity);

        if (Input.GetButton("Fire1") && hit.collider)
        {
            isHeld = true;
            if (isHeld)
                hit.collider.gameObject.transform.position = mousePos;
        }
        else
            isHeld = false; 
    }


    /// <summary>
    /// Call this function when a player has completed a puzzle through the drag and drop feature.
    /// </summary>
    public void OnDragCompletion()
    {

    }

}
