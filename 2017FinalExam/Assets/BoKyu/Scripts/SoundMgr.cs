using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMgr : MonoBehaviour {

    public AudioClip MusicClip;
    public AudioSource MusicSource;

    private void Awake()
    {
        Screen.SetResolution(1280, 720, false);

    }

    // Use this for initialization
    void Start () {

       
        MusicSource.clip = MusicClip;
        MusicSource.Play();

		
	}
	
	// Update is called once per frame
	void Update () {

	}
}
