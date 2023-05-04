using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RotateSite : MonoBehaviour
{
    public bool rotateToOrange = false;
    public bool rotateToGreen = false;
    public bool rotateToPink = false;
    public bool rotateToBlue = false;
    
    private Transform _orgTransform;
    private Vector3 _organgePos;
    private Quaternion _orangeEuler;
    private Vector3 _greenPos;
    private Quaternion _greenEuler;
    private Vector3 _pinkPos;
    private Quaternion _pinkEuler;
    private Vector3 _bluePos;
    private Quaternion _blueEuler;
    //The bigger the speed, the faster the transition
    private float _speed = 10f;
    private float timeCount = 0.0f;

    private void Start()
    {
        _orgTransform = transform;
        _organgePos = new Vector3(0, 12.05f, 7);
        _orangeEuler = Quaternion.Euler(160, 0, 0);
        _greenPos = new Vector3(-5.5f, 12.05f, -6.7f);
        _greenEuler = Quaternion.Euler(19.5f, 40f, 60f);
        _pinkPos = new Vector3(3.4f, 12.05f, 18f);
        _pinkEuler = Quaternion.Euler(160.5f, 30f, 120f);
        _bluePos = new Vector3(0, 0, 0);
        _blueEuler = Quaternion.Euler(-90f, 0, 0);
    }

    public void RotateToOrange()
    {
        rotateToOrange = true;
    }
    public void RotateToGreen()
    {
        rotateToGreen = true;
    }
    public void RotateToPink()
    {
        rotateToPink = true;
    }
    public void RotateToBlue()
    {
        rotateToBlue = true;
    }

    private void Update()
    {
        RotateAndMove(rotateToOrange,_organgePos,_orangeEuler);
        RotateAndMove(rotateToGreen,_greenPos,_greenEuler);
        RotateAndMove(rotateToPink,_pinkPos,_pinkEuler);
        RotateAndMove(rotateToBlue,_bluePos,_blueEuler);
    }
    
    private void RotateAndMove(bool b, Vector3 endPos, Quaternion endEuler)  
    {
        if (b)
        {
            if (Vector3.Distance(transform.position, endPos) > 0.1f)
            {
                transform.rotation = Quaternion.Slerp(_orgTransform.rotation, endEuler, timeCount);
                transform.position = Vector3.Slerp(_orgTransform.position, endPos, timeCount);
                timeCount += Time.deltaTime /_speed;
            }
            else
            {
                rotateToOrange = false;
                rotateToGreen = false;
                rotateToPink = false;
                rotateToBlue = false;
            }
            
        }
    }
}
