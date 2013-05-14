using UnityEngine;
using System.Collections;

public class p14_FerrisWheel : MonoBehaviour {
    public float m_fdegree;
    public GameObject[]  m_CarObject = new GameObject[8];
    public p14_Carriages[] m_CarScript = new p14_Carriages[8];


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
	}

    float RetureDeg() { return m_fdegree; }
	
	// Update is called once per frame
	void Update () {
        float t = Time.deltaTime;
        m_fdegree = t*10;
        transform.Rotate(0, m_fdegree,0);
        for (int i = 0; i < 8; i++) m_CarScript[i].SetDegree(m_fdegree);
	}
}
