using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Outline), typeof(Collider))]
public class Window : MonoBehaviour, IInteractable
{
    [SerializeField] private float _leftRot;
    [SerializeField] private float _rightRot;

    [SerializeField] private Transform _left;
    [SerializeField] private Transform _right;

    private Outline _outline;
    private bool _isOpen = false;

    private void Awake()
    {
        _outline = GetComponent<Outline>();
        _outline.enabled = false;
    }

    public void OnInteractStart()
    {
        _outline.enabled = true;
    }

    public void OnInteractStop()
    {
        _outline.enabled = false;
    }

    public void OnClicked()
    {
        //if (_isOpen) return;
        //_isOpen = true;

        _left.localEulerAngles = new Vector3(_left.localEulerAngles.x, _left.localEulerAngles.y, _leftRot);
        _right.localEulerAngles = new Vector3(_right.localEulerAngles.x, _right.localEulerAngles.y, _rightRot);

        //_outline.enabled = false;
        //this.enabled = false;

        //StartCoroutine(AnimationCoroutine(_left, 50f, 50f));
        //StartCoroutine(AnimationCoroutine(_right, 30f));
    }

    //private IEnumerator AnimationCoroutine(Transform obj, float angle, float delta)
    //{
    //    while (true)
    //    {
    //        obj.Rotate(Vector3.forward * delta * Time.deltaTime);

    //        float currAngle = obj.localEulerAngles.z;
    //        Debug.Log(currAngle);
    //        if (currAngle > angle)
    //        {
    //            Debug.Log($"broke {currAngle }; {angle}");
    //            break;
    //        }

    //        yield return null;
    //    }
    //}
}
