using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoButton : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    NoteContainer noteContainer;
    AudioSource audioSource;
    Coroutine highlightCouroutine;

    NotesTrainer notesTrainer;

    public AudioClip audioClip;
    public string noteName = "C3";

    void Awake()
    {
        // ищем нотный стан и объект трейнер
        noteContainer = GameObject.Find("NotesContainer").GetComponent<NoteContainer>();
        notesTrainer = GameObject.Find("NotesTrainer").GetComponent<NotesTrainer>();

        audioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void PlayNote()
    {
        Debug.Log("Нажата клавиша " + noteName);
        // Выводим ноту
        noteContainer.ShowNote(noteName);
        notesTrainer.PianoButtonPressed(noteName);

        HiglightPianoButton(Color.green);

        audioSource.clip = audioClip;
        audioSource.Play();
    }

    void HiglightPianoButton(Color color)
    {
        if(highlightCouroutine != null)
            StopCoroutine(highlightCouroutine);
        spriteRenderer.color = color;
        highlightCouroutine = StartCoroutine(HighlightCoroutine(Color.white));
    }

    private void OnMouseDown()
    {
        PlayNote();
    }

    IEnumerator HighlightCoroutine(Color color)
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            spriteRenderer.color = color;
        }
    }

}
