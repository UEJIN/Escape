using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// メイン
public class ButtonInput : MonoBehaviour
{
    //public FixedJoystick joystick;
    public ButtonState buttonA;
    public ButtonState buttonB;
    private FloatingJoystick floatingjoystick;
    private UnityChan2DController unityChan2DController;

    // 更新時に呼ばれる
    void OnEnable()
    {
        floatingjoystick = GameObject.Find("Floating Joystick").GetComponent<FloatingJoystick>();
        unityChan2DController = GameObject.Find("UnityChan2D").GetComponent<UnityChan2DController>();
    }

    void Update()
    {
        
        float x = Input.GetAxis("Horizontal") + floatingjoystick.Horizontal;
        bool jump = buttonA.IsDown();       //Aボタンでジャンプ
        unityChan2DController.Move(x, jump);


        // ボタンの状態表示
        //print("ButtonA Pressed: " + buttonA.IsPressed());
        //print("ButtonB Pressed: " + buttonB.IsPressed());
        //print("ButtonA Down: " + buttonA.IsDown());
        //print("ButtonB Down: " + buttonB.IsDown());
        //print("ButtonA Up: " + buttonA.IsUp());
        //print("ButtonB Up: " + buttonB.IsUp());
    }
}
