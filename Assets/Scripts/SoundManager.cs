using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;

    public static SoundManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<SoundManager>();
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }


    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (this != _instance)
                Destroy(this.gameObject);
        }
    }

    public GameObject AudioObject;
    public GameObject MuteButton;
    public GameObject SoundButton;

    public bool IsSoundOn = true;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (AudioObject == null)
        {
            AudioObject = GameObject.FindGameObjectWithTag("Audio");
            AudioObject.SetActive(IsSoundOn);
        }

        if (MuteButton == null)
        {
            MuteButton = GameObject.FindGameObjectWithTag("Mute");
            MuteButton.GetComponent<Button>().onClick.AddListener(() => SetSoundState(false));
            MuteButton.SetActive(IsSoundOn);
        }

        if (SoundButton == null)
        {
            SoundButton = GameObject.FindGameObjectWithTag("SoundOn");
            SoundButton.GetComponent<Button>().onClick.AddListener(() => SetSoundState(true));
            SoundButton.SetActive(!IsSoundOn);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            ChangeSoundState();
        }
    }

    private void ChangeSoundState()
    {
        IsSoundOn = !IsSoundOn;

        SetSoundState(IsSoundOn);
    }

    public void SetSoundState(bool state)
    {
        IsSoundOn = state;

        if (AudioObject != null)
        {
            AudioObject.SetActive(IsSoundOn);
        }

        if (MuteButton != null)
        {
            MuteButton.SetActive(IsSoundOn);
        }

        if (SoundButton != null)
        {
            SoundButton.SetActive(!IsSoundOn);
        }
    }
}
