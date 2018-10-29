using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : BehaviorTreeNode {
	private UnityEngine.GameObject projectile;
	private float firerate;
	private float countdown = -1;
	public Attack(UnityEngine.GameObject projectile, float firerate)
	{
		this.projectile = projectile;
		this.firerate = firerate;
	}
	public override int Act (BehaviorTree tree)
	{
		tree.transform.LookAt(player.transform);
		if(firerate > 0)
		{
			countdown -= Time.deltaTime;
			if(countdown < 0)
			{
				countdown = firerate;
				GameObject t = UnityEngine.Object.Instantiate(projectile, tree.transform.position, tree.transform.rotation);
			}
		}
		return -1;
	}
}
