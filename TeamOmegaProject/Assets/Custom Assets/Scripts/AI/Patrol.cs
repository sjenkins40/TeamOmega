using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : BehaviorTreeNode {
	private bool hastarget = false;
	private UnityEngine.AI.NavMeshAgent navmesh;
	public Patrol(UnityEngine.AI.NavMeshAgent navmesh)
	{
		this.navmesh = navmesh;
	}
	public override int Act (BehaviorTree tree)
	{
		if(!hastarget || (!navmesh.pathPending && navmesh.remainingDistance < 1))
		{
			Vector3 goal = tree.transform.position + tree.transform.rotation * new Vector3(hastarget?1000:0, 0, hastarget?0:1000);
			UnityEngine.AI.NavMeshHit hit;
			UnityEngine.AI.NavMesh.Raycast(tree.transform.position, goal, out hit, navmesh.walkableMask);
			goal = hit.position;
			hastarget = true;
			navmesh.SetDestination(goal);
		}
		return -1;
	}
}
