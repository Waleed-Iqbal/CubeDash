using UnityEngine;

public class ZSpinMechanism : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, 180 * Time.deltaTime);
	}
}
