using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteContainer : MonoBehaviour
{

    public GameObject[] noteArray;

    public List<GameObject> noteList;

    public Dictionary<string, GameObject> noteDict;

    // Start is called before the first frame update
    void Start()
    {
        // Тестирование вывода нот
        ShowNote("C3");
        ShowNote("D4");
        ShowNote("C2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowNote(string noteName)
    {
        //Функция показывает нужную ноту, убирая все остальные
        // Поиск ноты по строке, реализация не очень, но программа масштабироваться не будет - и так сойдет

        for (int i = 0; i < noteList.Count; i++)
            if (noteList[i].name.Contains(noteName))
                noteList[i].SetActive(true);
            else
                noteList[i].SetActive(false);


    }

}
