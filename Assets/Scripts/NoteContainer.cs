using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteContainer : MonoBehaviour
{
    public List<GameObject> noteList;
    Coroutine highlightCouroutine;

    // Start is called before the first frame update
    void Start()
    {
        HideAllNotes();
    }

    public void ShowNote(string noteName)
    {
        //Функция показывает нужную ноту, убирая все остальные
        // Поиск ноты по строке, реализация не очень, но программа масштабироваться не будет - и так сойдет
        HideAllNotes();

        for (int i = 0; i < noteList.Count; i++)
            if (noteList[i].name.Contains(noteName))
            {
                noteList[i].SetActive(true);
            }

    }

    public void HideAllNotes()
    {
        for (int i = 0; i < noteList.Count; i++)
                noteList[i].SetActive(false);
    }

    public GameObject GetNoteGameObjectByName(string noteName)
    {
        for (int i = 0; i < noteList.Count; i++)
            if (noteList[i].name.Contains(noteName))
                return noteList[i].gameObject;

        return null;
    }

    public void HighlightWrongNote(string noteName, Color color)
    {

        //Красим неправильную ноту, а затем прячем
        GameObject noteGameObject = GetNoteGameObjectByName(noteName);
        SpriteRenderer spriteRenderer = noteGameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = color;

        highlightCouroutine = StartCoroutine(AfterHighlightCoroutine(noteGameObject, spriteRenderer, Color.black));
    }


    IEnumerator AfterHighlightCoroutine(GameObject noteGameObject, SpriteRenderer spriteRenderer, Color color)
    {

        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            spriteRenderer.color = color;
            noteGameObject.SetActive(false);
        }
    }

}
