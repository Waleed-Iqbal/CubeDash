using UnityEngine;

public class YSpinMechanism : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 180 * Time.deltaTime, 0);
	}
}
