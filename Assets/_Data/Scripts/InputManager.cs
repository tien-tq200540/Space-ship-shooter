using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance { get => instance; }

    [SerializeField] protected Vector3 mouseWorldPos;
    public Vector3 MouseWorldPos { get => mouseWorldPos; }

    [SerializeField] protected float onFiring;
    public float OnFiring { get => onFiring; }

    protected Vector4 direction;
    public Vector4 Direction => direction;

    private void Awake()
    {
        if (instance != null) Debug.LogError("Only 1 InputManager allow to exist!");
        instance = this;
    }

    private void Update()
    {
        this.GetMouseDown();
        this.GetDirectionByKeyDown();
    }
    private void FixedUpdate()
    {
        this.GetMousePos();
    }

    protected virtual void GetMousePos()
    {
        mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    protected virtual void GetMouseDown()
    {
        onFiring = Input.GetAxis("Fire1");
    }

    protected virtual void GetDirectionByKeyDown()
    {
        this.direction.x = (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) ? 1 : 0; // Left
        this.direction.y = (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) ? 1 : 0; // Right
        this.direction.z = (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) ? 1 : 0; // Up
        this.direction.w = (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) ? 1 : 0; // Down

        
        if (this.direction.x == 1) Debug.Log("Left");
        if (this.direction.y == 1) Debug.Log("Right");
        if (this.direction.z == 1) Debug.Log("Up");
        if (this.direction.w == 1) Debug.Log("Down");
        
    }
}
