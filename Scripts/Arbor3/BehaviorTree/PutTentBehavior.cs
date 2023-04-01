using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;
using Arbor.BehaviourTree;
using System;
using UniRx;

[AddComponentMenu("")]
public class PutTentBehavior : ActionBehaviour {
	private ParameterContainer _parameter;
	public int putTentMillseconds;
	public int actionEndMillseconds;
	public GameObject tentPrefab;
	public Vector3 positionOffset;

	protected override void OnAwake() {
		_parameter = gameObject.GetComponent<ParameterContainer>();
	}

	protected override void OnStart() {
	}

	protected override void OnExecute() {
		_parameter.SetString("Action", "");
		this.behaviourTree.Pause();

		PutTent();
	}

	private void PutTent()
    {
		IObservable<long> actionEnd = Observable.Timer(dueTime: TimeSpan.FromMilliseconds(actionEndMillseconds));
		actionEnd.Subscribe(
			x => this.behaviourTree.Resume()
			).AddTo(this);

		IObservable<long> putTent = Observable.Timer(dueTime: TimeSpan.FromMilliseconds(putTentMillseconds));
		putTent.Subscribe(
			_ =>
			{
				GameObject tent = GameObject.Instantiate(tentPrefab);

				tent.transform.parent = this.transform;
				tent.transform.localPosition = -positionOffset / this.transform.localScale.x;
				tent.transform.parent = null;
			}
			).AddTo(this);
	}

	protected override void OnEnd() {
	}
}
