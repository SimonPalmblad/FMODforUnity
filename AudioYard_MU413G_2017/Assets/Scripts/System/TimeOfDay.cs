using UnityEngine;
using System.Collections;

public class TimeOfDay : MonoBehaviour
{
    public Animator animator;
    public ConditionTimed conditionTimed;
    private float normalizedTime;

	void Awake ()
    {
		normalizedTime = conditionTimed.startValue / conditionTimed.maxValue;
		
	}
	

	void Update ()
    {
        normalizedTime = Mathf.InverseLerp (conditionTimed.minValue, conditionTimed.maxValue, conditionTimed.dynamicCondition);
		animator.Play(0, 0, normalizedTime);
	}
}
