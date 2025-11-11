using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Swap : MonoBehaviour
{
    [SerializeField] private GameObject _cabin;
    [SerializeField] private GameObject _cinematicCamera;
    private bool _inCabin = false;
    private bool _isMoving = true;
    private float _notMovingTimer = 5f;
    [SerializeField] private float _notMovingRate = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraSwitch();
        if(Time.time > _notMovingTimer)
        {
            _isMoving = false;
        }
        if (Input.anyKey)
        {
            _isMoving = true;
            _notMovingTimer = Time.time + _notMovingRate;
        }
        if(_isMoving == false)
        {
            _inCabin = false;
            _cinematicCamera.SetActive(true);
        }
        else if(_isMoving == true)
        {
            _cinematicCamera.SetActive(false);
        }
    }

    public void CameraSwitch()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (_inCabin == false)
            {
                _cabin.SetActive(true);
                _inCabin = true;
            }
            else
            {
                _cabin.SetActive(false);
                _inCabin = false;
            }
        }
    }
}
