using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(CustomTriggerBox))]
/*@brief
Visualizes the trigger box in the scene view.
Use inspector values to change the position and size.
Handle feature greatly untested.*/
public class CustomTriggerboxEditor : Editor
{
    public void OnSceneGUI()
    {
        CustomTriggerBox triggerBox = (CustomTriggerBox)target;
        Vector3 position = triggerBox.transform.position + new Vector3(triggerBox.Point.x,triggerBox.Point.y,0);
        Vector3 size = new Vector3(triggerBox.Size.x,triggerBox.Size.y,0);
        
        Quaternion angle = Quaternion.Euler(0,0,triggerBox.Angle);
        if(triggerBox == null){
            Debug.LogError("target cast failed");
            return;
        }
        
        var color = new Color(1, 0, 0, 1);
        Handles.color = color;
        Handles.DrawWireCube(position,size);
        Handles.TransformHandle(ref position,ref angle,ref size);
        triggerBox.Point = new Vector2(position.x-triggerBox.transform.position.x,position.y-triggerBox.transform.position.y);
        triggerBox.Size = new Vector2(size.x,size.y);
        triggerBox.Angle = angle.eulerAngles.z;
        //TODO test angle property
    }
}
