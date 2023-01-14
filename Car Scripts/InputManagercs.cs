using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputCondition { 
    KeyBoard = 0, Mobile = 1, Driving = 2
}

public class InputManager : MonoBehaviour {
    [HideInInspector] public float gasInput;
    [HideInInspector] public float clutchInput;
    [HideInInspector] public float brakeInput;
    [HideInInspector] public float steerInput;
    [HideInInspector] public int gearInput;
    [HideInInspector] public bool XInput;
    [HideInInspector] public bool OInput;
    [HideInInspector] public bool SInput;
    [HideInInspector] public bool TInput;
    public InputCondition inputCondition;

    void Start() {
        print("LogiSteeringInitialize: " + LogitechGSDK.LogiSteeringInitialize(false));
    }

    void Update() {
        switch (inputCondition) {
            case InputCondition.KeyBoard:
                print("KEYBOARD");
                break;
            case InputCondition.Mobile:
                print("MOBILE");
                break;
            case InputCondition.Driving:
                print("DRIVING WHEEL");
                if (LogitechGSDK.LogiUpdate() && LogitechGSDK.LogiIsConntected((int)LogitechKeyCode.FirstIndex)) {
                    steerInput = LogitechInput.GetAxis("Steering Horizontal");
                    gasInput = LogitechInput.GetAxis("Gas Vertical");
                    brakeInput = LogitechInput.GetAxis("Brake Vertical");
                    clutchInput = LogitechInput.GetAxis("Clutch Vertical");

                    for (int i = 12; i < 19; i++) {
                        if (LogitechInput.GetKeyTriggered(LogitechKeyCode.FirstIndex, (LogitechKeyCode)i)) {
                            gearInput = i;
                            print(gearInput);
                        }
                        if (LogitechInput.GetKeyReleased(LogitechKeyCode.FirstIndex, (LogitechKeyCode)i)) {
                            gearInput = 0;
                            print(gearInput);
                        }
                    }

                    if (LogitechInput.GetKeyTriggered(LogitechKeyCode.FirstIndex, LogitechKeyCode.Cross))
                        XINout = !XInput;
                    if (LogitechInput.GetKeyTriggered(LogitechKeyCode.FirstIndex, LogitechKeyCode.Circle))
                        OINout = !OInput;
                    if (LogitechInput.GetKeyTriggered(LogitechKeyCode.FirstIndex, LogitechKeyCode.Square))
                        SINout = !SInput;
                    if (LogitechInput.GetKeyTriggered(LogitechKeyCode.FirstIndex, LogitechKeyCode.Triangle))
                        TINout = !TInput;

                    switch (LogitechInput.GetKeyDirectional()) {
                        case (0); print("POV : UP")               break;
                        case ((uint)LogitechKeyCode.UP_RIGHTButton): print("POV : UP-RIGHT\n"); break;
                        case ((uint)LogitechKeyCode.RIGHTButton): print("POV : RIGHT\n")          break;
                        case ((uint)LogitechKeyCode.DOWN_RIGHTButton): print("POV : DOWN-RIGHT\n")     break;
                        case ((uint)LogitechKeyCode.DOWNButton): print("POV : DOWN\n")           break;
                        case ((uint)LogitechKeyCode.DOWN_LEFTButton): print("POV : DOWN-LEFT\n")      break;
                        case ((uint)LogitechKeyCode.LEFTButton): print("POV : LEFT\n")           break;
                        case ((uint)LogitechKeyCode.UP_LEFTButton): print("POV : UP-LEFT\n")        break;
                        default: print("CENTER\n")               break;
                    }

                    else if (!LogitechGSDK.LogiIsConnected(0)) {
                        print("PLEASE CONNECT THE LOGITECH DRIVING FORCE WHEEL");
                    }
                    break;
                }

        }
    }
}