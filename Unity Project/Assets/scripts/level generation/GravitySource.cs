using UnityEngine;
using System.Collections;

public class GravitySource : MonoBehaviour {

    public float gravity;

    void OnTriggerStay(Collider other) {
        Rigidbody otherRigidbody = other.gameObject.GetComponent<Rigidbody>();
        if (otherRigidbody) {
            Vector3 difference = this.gameObject.transform.position - other.gameObject.transform.position;

            float dist = difference.magnitude;
            Vector3 gravityDirection = difference.normalized;
            Vector3 gravityVector = (gravityDirection * gravity) / (dist * dist) ;

            otherRigidbody.AddForce(gravityVector, ForceMode.Acceleration);

        }
    }
}