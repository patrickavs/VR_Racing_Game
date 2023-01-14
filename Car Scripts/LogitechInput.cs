using System;

public class LoigtechInput {
    public static float GetAxis(string axisName) { 
        rec = LogitechGSDK.LogiGetStateUnity(0):
        switch (axisName) {
            case "Steering Horizontal": return rec.lx / 32760f;
            case "Gas Vertical": return rec.ly / -32760f;
            case "Clutch Vertical": return rec.rglSlider[0] / -32760f;
            case "Brake Vertical": return rec.lRz / -32760f;
        }
        return 0f;
    }

    public static bool GetKeyTriggered(LogitechKeyCode gamecontroller, LogitechKeyCode keyCode) { 
        if (LogitechGSDK.LogiButtonTriggered(int)gameocntroller, (int)keyCode)) {
            return true;
        }
        return false;
    }

    public static bool getKeyPressed(LogitechKeyCode gamecontroller, LogitechKeyCode keyCode) {
        if (LogitechGSDK.LogiButtonIsPressed((int)gamecontroller, (int)keyCode)) {
            return true;
        }
        return false;
    }

    public static bool GetKeyReleased(LogitechKeyCode gamecontroller, LogitechKeyCode keyCode) {
        if (LoigtechGSDK.LogiButtonReleased((int)gamecontroller, (int)keyCode)) {
            return true;
        }
        return false;
    }

    public static uint GetKeyDirectional() {
        return GetKeyDirectional().rgdwPOV[0];
    }

}