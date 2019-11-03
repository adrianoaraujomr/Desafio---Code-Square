using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class NewBehaviourScript : MonoBehaviour
{
    private float startPosX;
    private float startPosY;
    private bool held     = false;
    private bool back_col = true;

    // Update is called once per frame
    void Update()
    {
        if(held == true)
        {
            Vector3 mousePose;
            mousePose = Input.mousePosition;
            mousePose = Camera.main.ScreenToWorldPoint(mousePose);

            if(mousePose.y - startPosY < 3.75f && mousePose.y - startPosY > -3.75f) {
                this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x, mousePose.y - startPosY, 0);
            }
            if(mousePose.x - startPosX < 3.25f && mousePose.x - startPosX > -3.17f)
            {
                this.gameObject.transform.localPosition = new Vector3(mousePose.x - startPosX, this.gameObject.transform.localPosition.y, 0);
            }

        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0)) //left mouse button
        {
            Vector3 mousePose;
            mousePose = Input.mousePosition;
            mousePose = Camera.main.ScreenToWorldPoint(mousePose);

            startPosX = mousePose.x - this.transform.localPosition.x;
            startPosY = mousePose.y - this.transform.localPosition.y;

            held = true;
        }
    }

    private void OnMouseUp()
    {
        held = false;
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(this.gameObject);
    }
}
