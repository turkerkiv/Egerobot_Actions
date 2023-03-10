using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] Outline _outline;

    public delegate void InteractEvent(Interactable interactable);
    public event InteractEvent OnInteract;

    Rigidbody _rigidbody;

    public LimitHandleMovement LimitHandleMovement { get; private set; }
    public Rigidbody Rigidbody => _rigidbody;
    public Outline Outline => _outline;
    public Transform Tip => _outline.transform;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        LimitHandleMovement = GetComponent<LimitHandleMovement>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerRightHand"))
        {
            LimitHandleMovement.PlayerRightHand = other.transform;
            OnInteract?.Invoke(this);
        }
    }
}