using UnityEngine;
using System.Collections;

public class TouchMoveScaleBroken : MonoBehaviour
{
    public GameObject Brokens;
    public Vector3 AonLimitPosition;
    public LayerMask Mask;

    // �O�_�u�O�u��V�W�A�_�h�u��V�U
    public bool isTop;

    private RaycastHit hit;
    private Ray ray;

    private Collider currentTouchesCollider;

    private Vector3 originalPosition;

    // Use this for initialization
    void Start()
    {
        this.originalPosition = this.transform.position;
        this.currentTouchesCollider = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.MetroPlayerARM)
        {
            this.ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(this.ray, out this.hit, 100, this.Mask) && Input.touches[0].phase == TouchPhase.Began)
            {
                if (this.hit.collider.Equals(this.collider))
                {
                    this.currentTouchesCollider = this.hit.collider;
                }
            }
            else if (Physics.Raycast(this.ray, out this.hit, 100, this.Mask) && Input.touches[0].phase == TouchPhase.Moved)
            {
                float offest = Input.touches[0].deltaPosition.y;
                
                if (this.isTop)
                {
                    this.currentTouchesCollider.gameObject.transform.position -= new Vector3(0, offest * 0.05f, 0);
                    if (this.currentTouchesCollider.gameObject.transform.position.y <= this.originalPosition.y)
                    {
                        this.currentTouchesCollider.gameObject.transform.position = this.originalPosition;
                    }
                    if (this.currentTouchesCollider.gameObject.transform.position.y <= this.AonLimitPosition.y)
                    {
                        this.currentTouchesCollider.gameObject.transform.position = this.AonLimitPosition;
                    }
                }
                else
                {
                    this.currentTouchesCollider.gameObject.transform.position += new Vector3(0, offest * 0.05f, 0);
                    if (this.currentTouchesCollider.gameObject.transform.position.y >= this.originalPosition.y )
                    {
                        this.currentTouchesCollider.gameObject.transform.position = this.originalPosition;
                    }
                    if (this.currentTouchesCollider.gameObject.transform.position.y <= this.AonLimitPosition.y)
                    {
                        this.currentTouchesCollider.gameObject.transform.position = this.AonLimitPosition;
                    }
                }
            }
            else if (Input.touches[0].phase == TouchPhase.Ended)
            {
                this.currentTouchesCollider = null;
            }
        }
        else
        {
            Debug.Log("Current device is not mobile. (Windows 8 RT, Android or iOS)");
        }
    }

    void OnGUI()
    {

    }
}
