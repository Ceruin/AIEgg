using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var hori = Input.GetAxisRaw("Horizontal") * speed;
        var verti = Input.GetAxisRaw("Vertical") * speed;
        transform.Translate(verti * Time.deltaTime, 0, -hori * Time.deltaTime);
    }

    void FixedUpdate()
    {

    }
}
