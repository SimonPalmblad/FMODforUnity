using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;


public class ConditionManager : MonoBehaviour
{


    [System.Serializable]
    public class ParameterSettings
    {
        public AnimationCurve curve;
        public string parameter;


        public void SetParameter(AudioMixer audioMixer, float value)
        {
			if (audioMixer != null)
			{
				audioMixer.SetFloat (parameter, curve.Evaluate (value));
			}
        }
    }


    public ParameterSettings[] parameters;
    public AudioMixer audioMixer;
    public enum ConditionMethod
    {
        useTimedCondition, useSlider, useSetCondition
    }
    public ConditionMethod conditionMethod;
    public ConditionTimed timedCondition;
    public Slider slider = null;
    private float sliderValue;
    public float setCondition;


    void Awake()
    {
        if (slider != null && conditionMethod == ConditionMethod.useSlider)
        {
            sliderValue = slider.value;
            SetValue(sliderValue);
        }
        else if (timedCondition != null && conditionMethod == ConditionMethod.useTimedCondition)
        {
            SetValue(timedCondition.dynamicCondition);
        }
        else
        {
            
            SetValue(setCondition);
        }

    }

    void Update()
    {
        if (slider != null && conditionMethod == ConditionMethod.useSlider)
        {
            sliderValue = slider.value;
            SetValue(sliderValue);
        }
        else if (timedCondition != null && conditionMethod == ConditionMethod.useTimedCondition)
        {
            SetValue(timedCondition.dynamicCondition);
        }
        else
        {
            SetValue(setCondition);
        }
    }


    public void SetValue(float value)
    {
        //	Condition value
        for (int i = 0; i < parameters.Length; i++)
        {
            parameters[i].SetParameter(audioMixer, value);
            
        }
    }

    public void SetConditionValue(float staticValue)
    {
        if (setCondition == staticValue)
        {
            setCondition = 0f;
            SetValue(setCondition);
        }
        else
        {
            setCondition = staticValue;
            SetValue(setCondition);
        }
    }
}
