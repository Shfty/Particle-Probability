using UnityEngine;
using System.Collections;

public class ParticleDeath : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine ("DoEvent");
	}
	
	IEnumerator DoEvent()
	{
		yield return new WaitForSeconds(5.0f);
		Destroy( gameObject );
	}
}
