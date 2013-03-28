using UnityEngine;
using System.Collections;

public class ObjectRotate : MonoBehaviour
{
    public GameObject CentralObject;

    private Vector3 vec3;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.CentralObject != null)
        {
            
            this.vec3 = this.CentralObject.transform.position;
            this.transform.RotateAround(this.vec3, new Vector3(0.0f, 0.0f, this.vec3.z), Input.GetTouch(0).deltaPosition.x * (-0.1f));
            
        }
        print("Input.touchCount = " + Input.touchCount + " .");
    }

    void OnGUI()
    {
        string str = string.Format("Input.touchCount = {0}\nDeltaPosition = {1} .", Input.touchCount, Input.GetTouch(0).deltaPosition);
        string str2 = string.Format("Rotate = ({0}, {1}, {2})", this.transform.rotation.eulerAngles.x, this.transform.rotation.eulerAngles.y, this.transform.rotation.eulerAngles.z);
        GUI.Label(new Rect(Screen.currentResolution.width / 2 - 150, Screen.currentResolution.height / 2 - 100, 300, 200), str + "\n" + str2);
    }
}
