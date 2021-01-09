using UnityEngine;
using System.Collections;

public class BluetoothEventListener : MonoBehaviour {

    void ConnectionStateEvent(string state)
    {
     
        switch (state)
        {
            case "STATE_CONNECTED":

                break;
            case "STATE_CONNECTING":

                break;
            case "UNABLE TO CONNECT":

                break;
        }
        Debug.Log(state);
    }

    void DoneSendingEvent(string writeMessage)
    {
        Debug.Log("writeMessage " + writeMessage);  
    }

    void DoneReadingEvent(string readMessage)
    { 
        Debug.Log("readMessage " + readMessage); 
    }

    void FoundDeviceEvent(string Device)
    {
        Debug.Log("FoundDeviceEvent");
    }

    void FoundZeroDeviceEvent()
    {  
        Debug.Log("FoundZeroDeviceEvent");
    }

    void ScanFinishEvent()
    {
        Debug.Log("ScanFinishEvent");
    }

   

}