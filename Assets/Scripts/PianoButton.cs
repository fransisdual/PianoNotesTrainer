using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoButton : MonoBehaviour
{

    NoteContainer noteContainer;
    AudioSource audioSource;

    public AudioClip audioClip;
    public string noteName = "C3";

    void Awake()
    {
        noteContainer = GameObject.Find("NotesContainer").GetComponent<NoteContainer>();
        audioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>(); 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayNote()
    {
        Debug.Log("Нажата клавиша ");
        noteContainer.ShowNote(noteName);

        audioSource.clip = audioClip;
        audioSource.Play();
    }

    private void OnMouseDown()
    {
        PlayNote();
    }
}
