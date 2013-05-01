using UnityEngine;
using System.Collections;

public class PageTurn : MonoBehaviour
{
    public enum SceneName
    {
        page0 = 0,
        page1 = 1,
        page2,
        page3,
        page4,
        page5,
        page7,
        page8,
        page9,
        page11,
        page14,
        page15,
        page17,
        page18,
        page19,
        page20,
        page21,
        page24,
        page27
    }

    public SceneName TurnToPage;

    private Collider touchCollider;

    public LayerMask mask;
    private RaycastHit hit;
    private Ray ray;

    // Use this for initialization
    void Start()
    {

        this.touchCollider = null;
        //this.mask = 0 + 1 + 2 + 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.MetroPlayerARM)
        {
            this.ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            if (Physics.Raycast(this.ray, out this.hit, 100, this.mask) && Input.touches[0].phase == TouchPhase.Began)
            {
                this.touchCollider = null;
                if (this.hit.collider.Equals(this.collider))
                {
                    this.touchCollider = this.hit.collider;
                }
            }
            else if (Physics.Raycast(this.ray, out this.hit, 100, this.mask) && Input.touches[0].phase == TouchPhase.Ended)
            {
                if (this.touchCollider)
                {
                    if (this.touchCollider.Equals(this.collider))
                    {
                        Application.LoadLevel((int)this.TurnToPage);
                    }
                }
            }
        }
        else
        {
            Debug.Log("Current device is not mobile. (Windows 8 RT, Android or iOS)");
        }
    }
}
