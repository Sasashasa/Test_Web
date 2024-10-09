using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Animator))]
public class Button : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private LoadSprites _loadSprites;
    
    private static readonly int _clicked = Animator.StringToHash("clicked");
    private bool _isFirstClick = true;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!_isFirstClick)
            return;
        
        _isFirstClick = false;
        GetComponent<Animator>().SetBool(_clicked, true);
        
        _loadSprites.load();
    }
}