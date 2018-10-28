using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemyTree : BehaviorTree {
	// Use this for initialization
	void Start () {
		navmesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
		if (navmesh == null)
			Debug.Log("NavMeshAgent could not be found");
		root = new Sequence(
							new Alternator(
									new Sequence(
											new WaitForPlayer(5),
											new SendAlert(3)),
									new Patrol(),
									new Alert(25)),
							new Timeout(10f,
									new ChasePlayer(2)));
	}
}
