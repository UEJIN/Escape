using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipGround : MonoBehaviour
{
    public float SpeedGradation = 0.1f;
    public float Friction = 500;
    private float Speed;
    public float maxSpeed = 5f;
    private FloatingJoystick floatingjoystick;
    private UnityChan2DController unityChan2DController;

    
    // çXêVéûÇ…åƒÇŒÇÍÇÈ
    void OnEnable()
    {
        floatingjoystick = GameObject.Find("Floating Joystick").GetComponent<FloatingJoystick>();
        unityChan2DController = GameObject.Find("UnityChan2D").GetComponent<UnityChan2DController>();
    }
    // Start is called before the first frame update
    void Start()
    {
            Speed = 0;
    }
    void FixedUpdate()
    {
        //à⁄ìÆë¨ìxÇÃåvéZ
        if (Input.GetAxis("Horizontal") + floatingjoystick.Horizontal > 0)
        {
            if (maxSpeed > Speed)
            {
                Speed += maxSpeed * SpeedGradation;
            }

        }

        if (Input.GetAxis("Horizontal") + floatingjoystick.Horizontal < 0)
        {
            if (-maxSpeed < Speed)
            {
                Speed -= maxSpeed * SpeedGradation;
            }
        }

    }
    void Update()
    {
        //à⁄ìÆë¨ìxÇÃîΩâf
        if (Input.GetAxis("Horizontal") + floatingjoystick.Horizontal < 0)
        {
            unityChan2DController.maxSpeed = -Speed;
        }
        if (Input.GetAxis("Horizontal") + floatingjoystick.Horizontal > 0)
        {
            unityChan2DController.maxSpeed = Speed;
        }

        //ìôë¨â^ìÆ
        if (Input.GetAxis("Horizontal") + floatingjoystick.Horizontal == 0)
        {
            GameObject.Find("UnityChan2D").transform.Translate(Mathf.Abs(Speed) / Friction, 0, 0);

        }
    }
}
