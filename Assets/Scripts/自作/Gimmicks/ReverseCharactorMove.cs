using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseCharactorMove : MonoBehaviour
{
    UnityChan2DController unityChan2DController;

    // Start is called before the first frame update
    void OnEnable()
    {
        unityChan2DController = GameObject.Find("UnityChan2D").GetComponent<UnityChan2DController>();
        unityChan2DController.maxSpeed = unityChan2DController.maxSpeed * (-1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDisable()
    {
        
    }

}
