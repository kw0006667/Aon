using UnityEngine;
using System.Collections;

public class MissionCompleted : MonoBehaviour
{
    public LayerMask mask;
    
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
        if (Physics.Raycast(this.ray,out this.hit, 100, this.mask))
        {
            if (hit.collider.Equals(this.collider))
            {
                Application.LoadLevel(1);
            }
        }
    }

    void OnGUI()
    {
        string str = string.Format("Input.GetTouche(0).position = ({0}, {1}).", this.ray.GetPoint(100).x, this.ray.GetPoint(100).y);
        GUI.Label(new Rect(50, 50, 200, 100), str);
    }
}
