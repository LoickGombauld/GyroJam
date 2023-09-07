using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public static UIManager instance;


    [SerializeField] private Material baseMaterial;
    [SerializeField] private Material hoverMaterial;
    [SerializeField] private Material pressedMaterial;



    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }



    public void OnHover()
    {

    }


    public void OnPress()
    {

    }


    public void OnClick()
    {

    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
