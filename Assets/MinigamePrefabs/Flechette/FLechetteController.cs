using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class FLechetteController : MonoBehaviour
{
    public float fSpeed = 1f;
    public float fTimeElapsed = 0f;
    public GameObject goCursor, goTarget;
    public bool canMove = true;

    public Transform tfPosLeft, tfPosRight, tfPosTop, tfPosBottom; 

    // Start is called before the first frame update
    void Start()
    {
        goCursor.transform.position = tfPosLeft.position;
    }

    public void OnLeftButton(InputAction.CallbackContext context)
    {
        if(context.phase != InputActionPhase.Performed)
            return;

        canMove = false;

        if (Vector3.Distance(goCursor.transform.position, goTarget.transform.position) <= goTarget.GetComponent<RectTransform>().sizeDelta.x)
            Debug.Log("win");
        else
            Debug.Log("lose");

        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            goCursor.transform.position = new Vector3(
                Mathf.Lerp(tfPosLeft.position.x, tfPosRight.position.x, Mathf.Sin(Mathf.PingPong(Time.time, 1))),
                Mathf.Lerp(tfPosTop.position.y, tfPosBottom.position.y, Mathf.Cos(Mathf.PingPong(Time.time * 2, 1))),
                goCursor.transform.position.z);
        }
    }
}
