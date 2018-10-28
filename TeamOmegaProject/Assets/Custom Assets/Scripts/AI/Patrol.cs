﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : BehaviorTreeNode {
	private bool hastarget = false;
	public override int Act (BehaviorTree tree)
	{
		if(!hastarget || (!tree.navmesh.pathPending && tree.navmesh.remainingDistance < 1))
		{
			Vector3 goal = tree.transform.position + tree.transform.rotation * new Vector3(hastarget?1000:0, 0, hastarget?0:1000);
			UnityEngine.AI.NavMeshHit hit;
			UnityEngine.AI.NavMesh.Raycast(tree.transform.position, goal, out hit, tree.navmesh.walkableMask);
			goal = hit.position;
			hastarget = true;
			tree.navmesh.SetDestination(goal);
		}
		return -1;
	}
}
