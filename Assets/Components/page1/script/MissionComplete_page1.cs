using UnityEngine;
using System.Collections;

public class MissionComplete_page1 : MonoBehaviour
{
    public GameObject TargetObject;
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
        this.ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        if (Physics.Raycast(this.ray, out this.hit, 100, this.Mask))
        {
            if (this.hit.collider.Equals(this.TargetObject.collider))
            {
                Application.LoadLevel("page2");
            }
        }
    }
}
