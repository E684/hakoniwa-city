using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;

[AddComponentMenu("")]
public class LocomotionSpeedCalculator : Calculator {
	[SerializeField]
	private FlexibleGameObject gameobject = new FlexibleGameObject();

	[SerializeField] private OutputSlotVector3 _Result = new OutputSlotVector3();

	// Use this for calculate
	public override void OnCalculate() {
		HakoniwaCityInputs inputs = gameobject.value.GetComponent<HakoniwaCityInputs>();

		if(inputs != null)
        {
			_Result.SetValue(inputs.speed);
		}
	}
}
