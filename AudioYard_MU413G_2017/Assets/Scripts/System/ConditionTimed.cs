using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ConditionTimed : MonoBehaviour
{
    [HideInInspector]
    public float dynamicCondition;
	[HideInInspector]
	public float minValue, startValue, maxValue;
    public float conditionSpeed = 2f;
	[HideInInspector]
	public Slider slider;
    [HideInInspector]
    public bool runActive = false;
    public bool run = false;
    private bool counterRunning = false;
	[HideInInspector]
	public Toggle toggle;
	[HideInInspector]
	public AudioManager audioManager;
    
    void Awake()
    {
        dynamicCondition = startValue;
		audioManager = GameObject.FindObjectOfType<AudioManager> ();
    }

    void Update()
    {
       
        if (slider!= null)
        {
            slider.value = dynamicCondition;
        }

        if (toggle != null)
        {
            toggle.isOn = run;
                                   
        }
        else
        {
            runActive = run;
            if (runActive && counterRunning == false)
            {
                StartCoroutine(Counter());
                counterRunning = true;
            }
            else
            {
                counterRunning = false;
                StopAllCoroutines();
            }
        }
    }

    public void Run()
    {
        if (runActive)
        { 
            runActive = false;
            run = false;
            counterRunning = false;
            StopAllCoroutines();
        }
        else
        {
            runActive = true;
            run = true;
            StartCoroutine(Counter());
        }
    }

    IEnumerator Counter()
    {
        
        while (dynamicCondition <= maxValue)
        {
            dynamicCondition += conditionSpeed * Time.deltaTime / 100;
			audioManager.Timeofday (dynamicCondition);
			yield return null;
        }
        dynamicCondition = minValue;
        if (runActive)
        {
            StartCoroutine(Counter());
        }
        counterRunning = false;
    }

    

}
