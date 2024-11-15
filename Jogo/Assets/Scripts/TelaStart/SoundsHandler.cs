using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SoundsHandler : MonoBehaviour
{
    private Button button;
    private AudioSource audioSource;
    public AudioClip clickSound;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clickSound;

        button.onClick.AddListener(PlayClick);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void PlayClick()
    {
        Debug.Log ("You have clicked the button!");
        audioSource.Play();
    }
}
