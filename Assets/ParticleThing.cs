using UnityEngine;
using System.Collections;

public class ParticleThing : MonoBehaviour {

	public GameObject ParticlePrefab;

	float a = 10.0f;
	float b = 35.0f;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("FireParticle", 0, 0.01f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FireParticle () {
		GameObject foo = GameObject.Instantiate (ParticlePrefab);

		foo.transform.position = transform.position;
		foo.transform.eulerAngles = new Vector3( 0.0f, 0.0f, particleAngle( a, b ));
		foo.GetComponent<Rigidbody2D>().AddRelativeForce( new Vector2( 100.0f, 0.0f ) );
	}

	float particleAngle( float alpha, float beta )
	{
		float angle = 0.0f;
		float which = Random.Range (0.0f, 1.0f);
		float sign = Mathf.Sign ( Random.Range (-1.0f, 1.0f) );
		if (which <= 0.5f) {
			angle = alpha * Random.Range ( 0.0f, 1.0f );
		} else {
			angle = alpha + ( beta * monteCarlo() );
		}

		return angle * sign;
	}

	float monteCarlo()
	{
		while (true) {
			float r1 = Random.Range (0.0f, 1.0f);
			float p = r1;
			float r2 = Random.Range (0.0f, 1.0f);
			if( r2 > p )
			{
				return r1;
			}
		}
	}

	void OnDrawGizmos()
	{
		Vector3 offset = new Vector3 (10.0f, 0.0f, 0.0f);
		Vector3 offsetAlphaA = Quaternion.AngleAxis (a, Vector3.forward) * offset;
		Vector3 offsetAlphaB = Quaternion.AngleAxis (-a, Vector3.forward) * offset;
		Vector3 offsetBetaA = Quaternion.AngleAxis (a + b, Vector3.forward) * offset;
		Vector3 offsetBetaB = Quaternion.AngleAxis (-(a + b), Vector3.forward) * offset;
		
		Gizmos.color = Color.white;
		Gizmos.DrawLine (transform.position, transform.position + offset);

		Gizmos.color = Color.green;
		Gizmos.DrawLine (transform.position, transform.position + offsetAlphaA);
		Gizmos.DrawLine (transform.position, transform.position + offsetAlphaB);

		Gizmos.color = Color.red;
		Gizmos.DrawLine (transform.position, transform.position + offsetBetaA);
		Gizmos.DrawLine (transform.position, transform.position + offsetBetaB);
	}
}
