using UnityEngine;


public class Rotate : MonoBehaviour {
  public Vector3 axis = Vector3.up;
  public float angularSpeed = 20.0f;


    public static Rotate instance = null;

    private void Update() {
    gameObject.transform.Rotate(axis, angularSpeed * Time.deltaTime, Space.World);
  }

  void Awake(){
    
  }
}