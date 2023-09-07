using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


[RequireComponent(typeof(Image))]
public class ButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{

    [Header("Button Animations")]
    [SerializeField] private bool _animatingButton;
    [SerializeField][Range(0, 3)] private float _offset = 0.07f;
    [SerializeField][Range(0, 3)] private float _animationDuration = 0.003f;

    private bool moving;
    private Vector3 _basePosition;

    [Header("Button Sizes")]
    [SerializeField][Range(0, 2)] private float _switchSpeed = 1.3f;

    [SerializeField][Range(0, 2)] private float _baseScale = 1.0f;
    [SerializeField][Range(0, 2)] private float _hoverScale = 1.15f;
    [SerializeField][Range(0, 2)] private float _clickScale = 1.2f;




    [Header("Button Materials")]
    [SerializeField] private Material _baseMaterial;
    [SerializeField] private Material _hoverMaterial;
    [SerializeField] private Material _clickMaterial;


    [Header("Button Events")]
    [SerializeField] private UnityEvent PointerEnterEvent;
    [SerializeField] private UnityEvent PointerExitEvent;
    [SerializeField] private UnityEvent PointerClickEvent;


    private Image _buttonImage;
    private Vector3 targetScale = new Vector3(1,1,1);

    void Start()
    {
        _buttonImage = GetComponent<Image>();
        _basePosition = transform.position;
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        PointerEnterEvent.Invoke();
        targetScale = new Vector3(_hoverScale, _hoverScale, _hoverScale);
        SetMaterial(_hoverMaterial);

        AudioManager.instance.PlaySound(AudioManager.instance._hoverSound, AudioManager.instance.volumeScale);
    }



    public void OnPointerExit(PointerEventData eventData)
    {

        PointerExitEvent.Invoke();
        targetScale = new Vector3(_baseScale, _baseScale, _baseScale);
        SetMaterial(_baseMaterial);
    }



    public void OnPointerDown(PointerEventData eventData)
    {
        PointerClickEvent.Invoke();
        targetScale = new Vector3(_clickScale, _clickScale, _clickScale);
        SetMaterial(_baseMaterial);

        AudioManager.instance.PlaySound(AudioManager.instance._clickSound, AudioManager.instance.volumeScale);

    }






    public void SetMaterial(Material newMaterial)
    {
        _buttonImage.material = newMaterial;
    }






    void Update()
    {
        SetScale(targetScale);

        if (_animatingButton)
        {
            if (transform.position == _basePosition + new Vector3(0, _offset, 0))
            {
                moving = false;
            }
            if (transform.position == _basePosition + new Vector3(0, -_offset, 0))
            {
                moving = true;
            }


            if (moving)
            {
                transform.position = Vector3.MoveTowards(transform.position, _basePosition + new Vector3(0, _offset, 0), _animationDuration);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, _basePosition + new Vector3(0, -_offset, 0), _animationDuration);
            }
        }
        
    }

    public void SetScale(Vector3 newScale)
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, newScale, _switchSpeed * Time.deltaTime);
    }

}

