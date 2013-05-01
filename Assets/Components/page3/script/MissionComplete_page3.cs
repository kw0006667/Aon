using UnityEngine;
using System.Collections;

public class MissionComplete_page3 : MonoBehaviour
{
    public GameObject TaretObject;
    public LayerMask Mask;

    private RaycastHit hit;
    private Ray ray;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.MetroPlayerARM)
        {
            this.ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            if (Physics.Raycast(this.ray, out this.hit, 100, this.Mask) && Input.touches[0].phase == TouchPhase.Ended)
            {
                if (this.hit.collider.Equals(this.TaretObject.collider) && this.TaretObject.renderer.material.GetColor("_Color").a >= 0.7f)
                {
                    Application.LoadLevel("page4");
                }
            }
        }
        else
        {
            Debug.Log("Current device is not mobile. (Windows 8 RT, Android or iOS)");
        }
    }

    void OnGUI()
    {
        //GUI.Label(new Rect(Screen.currentResolution.width / 2 - 100, Screen.currentResolution.height / 2 - 50, 200, 100), this.TaretObject.renderer.material.GetColor("_Color").a.ToString());
    }
}
