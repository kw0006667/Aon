using UnityEngine;
using System.Collections;

public class ObjectTrigger : MonoBehaviour
{
    public bool isTouched;

    private Vector3 originalPosition;
    private Vector2 deltaPositionTemp;

    // Use this for initialization
    void Start()
    {
        this.isTouched = false;
        this.originalPosition = this.transform.position;
        this.deltaPositionTemp = new Vector2();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount >= 1)
        {
            this.deltaPositionTemp = Input.GetTouch(0).deltaPosition;
            this.transform.position += new Vector3(this.deltaPositionTemp.x * 0.03f, 0.0f, 0.0f);
            if (this.transform.position.x <= this.originalPosition.x)
                this.transform.position = this.originalPosition;
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.currentResolution.width / 2 - 200, Screen.currentResolution.height / 2 - 100, 100, 50), "This.isTouched = " + this.isTouched.ToString());
    }

    void OnTriggerEnter(Collider col)
    {
        Destroy(col);
    }
}
