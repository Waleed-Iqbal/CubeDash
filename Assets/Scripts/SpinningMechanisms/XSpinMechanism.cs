using UnityEngine;

public class XSpinMechanism : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        transform.Rotate(180 * Time.deltaTime, 0, 0);
	}
}
