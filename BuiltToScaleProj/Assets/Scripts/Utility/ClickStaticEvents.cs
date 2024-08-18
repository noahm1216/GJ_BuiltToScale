using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// <para> Handles simple click --> to event cases like switching 'modes' </para>
/// </summary>
public class ClickStaticEvents : MonoBehaviour
{

    public UnityEvent onClickEvents;
    public bool isLockedFromActivating;


    private void OnMouseDown()
    {
        if (isLockedFromActivating)
            return;

        //print($"mouse down on: {transform.name}");
        onClickEvents.Invoke();
    }
}
