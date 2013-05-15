using UnityEngine;
using System.Collections;

public class p14_FerrisWheel : MonoBehaviour {
    public float m_fdegree; // 目前轉動的角度
    public GameObject[]  m_CarObject = new GameObject[8];
    public p14_Carriages[] m_CarScript = new p14_Carriages[8];
    public Vector2 tp;
    public Vector2 m_FWCenter;
    public Ray touchRay;


	// Use this for initialization
	void Start () {
        m_fdegree = 0; // 預設為0度	
        m_CarObject[0] = GameObject.Find("aonp14_i_fun11");
        m_CarObject[1] = GameObject.Find("aonp14_i_fun12");
        m_CarObject[2] = GameObject.Find("aonp14_i_fun13");
        m_CarObject[3] = GameObject.Find("aonp14_i_fun14");
        m_CarObject[4] = GameObject.Find("aonp14_i_fun15");
        m_CarObject[5] = GameObject.Find("aonp14_i_fun16");
        m_CarObject[6] = GameObject.Find("aonp14_i_fun17");
        m_CarObject[7] = GameObject.Find("aonp14_i_fun18");
        for( int i = 0 ; i < 8 ; i++ ) 
            m_CarScript[i] = m_CarObject[i].GetComponent<p14_Carriages>();

        m_FWCenter.x = -2.56767f; m_FWCenter.y = 0.5497255f;
	}
	
	// Update is called once per frame
	void Update () {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.MetroPlayerARM)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                // 根據拖曳來計算轉動的角度
                // Get movement of the finger since last frame
                touchRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                if (touchRay.origin.x >= -4.8f && touchRay.origin.x <= 0.6f && touchRay.origin.y >= -1.5f && touchRay.origin.y <= 3.5f)
                {
                    // 分成四個象限來處理
                    tp = Input.GetTouch(0).deltaPosition;
                    if (touchRay.origin.x >= m_FWCenter.x) {
                        if ( touchRay.origin.y >= m_FWCenter.y) { // I 象限
                            if (tp.x < 0) {
                                m_fdegree = -(tp.x * tp.x + tp.y * tp.y) * 0.5f;
                            }
                            else {
                                m_fdegree = (tp.x * tp.x + tp.y * tp.y) * 0.5f;
                            }
                        }
                        else { // IV 象限

                        }
                    }
                    else {
                        if ( touchRay.origin.y >= m_FWCenter.y ) { // II 象限

                        }
                        else  { // III 象限

                        }
                    } 

                    // 根據點的位置 與 tp 的內容來設定轉動的方向

//                    float t = Time.deltaTime;
                    transform.Rotate(0, m_fdegree, 0);
                    for (int i = 0; i < 8; i++) m_CarScript[i].SetDegree(m_fdegree); // 有呼叫才需要轉動一次, 採用一步到位的方式執行?
                    m_fdegree = 0;

                }
            }
        }

	}

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.currentResolution.width / 2, Screen.currentResolution.height / 2, 200, 50), tp.ToString());
        GUI.Label(new Rect(Screen.currentResolution.width / 2, Screen.currentResolution.height / 2-300, 200, 50), touchRay.ToString());
    }
}

