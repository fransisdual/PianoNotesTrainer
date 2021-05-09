using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesTrainer : MonoBehaviour
{

    public NoteContainer noteContainer;

    public string currentNoteName;
    GameObject currentNoteGameObject;

    // Start is called before the first frame update
    void Start()
    {
        SetRandomNote();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentNoteGameObject.active == false)
            currentNoteGameObject.SetActive(true);
    }

    void SetRandomNote()
    {
        int noteIndex = Random.Range(0, noteContainer.noteList.Count);

        currentNoteName = noteContainer.noteList[noteIndex].name;

        noteContainer.ShowNote(currentNoteName);

        currentNoteGameObject = noteContainer.GetNoteGameObjectByName(currentNoteName);
    }

    void HighliteWrongNote(string noteName)
    {
        noteContainer.HighlightWrongNote(noteName, Color.red);
    }

    public void PianoButtonPressed(string pressedNoteName)
    {
        if (pressedNoteName == currentNoteName)
        {
            Debug.Log("Нажата правильная нота");
            SetRandomNote();
            noteContainer.ShowNote(currentNoteName);

        }
        else
        {
            Debug.Log("Нажата неправильная нота!");
            HighliteWrongNote(pressedNoteName);
            
        }
            
    }





}
