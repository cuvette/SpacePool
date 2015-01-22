using UnityEngine;
using System.Collections;

public class OverlapInstantiator
{

	public static Object OverInstantiate(GameObject objectToInstantiate, Vector3 position, float maximumDistance)
	{
		Collider[] cols;
//		if(cols.Length == 0)
//		{
//			MonoBehaviour.Instantiate(objectToInstantiate, position, Random.rotation);
//		}
		bool empty = false;
		int count = 0;
		while(!empty)
		{
			cols = Physics.OverlapSphere(position, objectToInstantiate.transform.localScale.x, LayerMask.GetMask("Astre"));
			if(cols.Length == 0 || count >= 100)
			{
				empty = true;
			}
			else
			{
				Vector3 temp = position + Random.insideUnitSphere.normalized;
			}
			count++;
		}

		return MonoBehaviour.Instantiate(objectToInstantiate, position, Random.rotation);
	}
}
