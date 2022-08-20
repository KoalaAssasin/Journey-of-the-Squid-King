using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class menu_manager : MonoBehaviour
{
    public enum TYPE
    {
        NONE,
        PLAY,
        EXIT,
        GOTOMENU
    }

    public float timeBetweenNextInterval = 2.0f;
    float time = 1.0f;
    bool notTime;

    public TYPE type = TYPE.NONE;

    // Start is called before the first frame update
    void Start()
    {
        //add an eventTrigger to game object
        EventTrigger trigger = gameObject.AddComponent<EventTrigger>();
        //add entries
        EventTrigger.Entry entry = new EventTrigger.Entry();
        EventTrigger.Entry exit = new EventTrigger.Entry();
        //add events
        entry.eventID = EventTriggerType.PointerDown;
        exit.eventID = EventTriggerType.PointerUp;
        //call functions
        entry.callback.AddListener((e) => { OnPointerDown((PointerEventData)e); });
        exit.callback.AddListener((e) => { OnPointerUp((PointerEventData)e); });
        //add it to the event trigger component attached to the game object
        trigger.triggers.Add(entry);
        trigger.triggers.Add(exit);
    }

    // Update is called once per frame
    void Update()
    {
        if (notTime)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                //reset time
                time = timeBetweenNextInterval;
                switch (type)
                {
                    case TYPE.PLAY:
                        {
                            SceneManager.LoadScene(1);
                            break;
                        }
                    case TYPE.EXIT:
                        {
                            Application.Quit();
                            break;
                        }
                    case TYPE.GOTOMENU:
                        {
                            //load the menu scene
                            SceneManager.LoadScene(0);
                            break;
                        }
                }
                notTime = false;
            }
        }
    }

    public void OnPointerDown(PointerEventData e)
    {
        //can do some stuff
    }

    public void OnPointerUp(PointerEventData e)
    {
        //can do other stuff
        notTime = true;
    }

    public void RestartCurrentScene()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }
}

