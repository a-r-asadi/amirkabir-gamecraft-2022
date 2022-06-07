using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    private State state;

    // Start is called before the first frame update
    private void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SetStateToPlaying()
    {
        state = State.PLAYING;
    }
    
    public void SetStateToFinished()
    {
        state = State.FINISHED;
    }

    public State GetState()
    {
        return state;
    }
    
    public enum State
    {
        PLAYING,
        FINISHED
    }
}
