using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ImageLogo : MonoBehaviour
{
    private Image ref_Image;
    public Sprite[] spriteArray;
    public float anim_Speed = 0.2f;
    private int currentSpriteIndex;
    private float timer;
    public bool loop = true;

    private void Start()
    {
        ref_Image = GetComponent<Image>();
        if(ref_Image == null)
        {
            Debug.LogError("O componente");
            enabled = false;
            return;
        }
        ResetAnimation();
    }
    private void OnEnable()
    {
        if(ref_Image != null)
            ResetAnimation();
    }

    private void Update()
    {
        if(ref_Image == null || spriteArray.Length == 0) return;
        
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            currentSpriteIndex++;
            if (currentSpriteIndex >= spriteArray.Length)
            {
                if (loop)
                {
                    currentSpriteIndex = 0;
                }
                else
                {
                    currentSpriteIndex = spriteArray.Length - 1; // Usar o último índice válido
                    enabled = false; // Desabilitar o script para parar a animação
                }
            }

            ref_Image.sprite = spriteArray[currentSpriteIndex]; // Corrigir o acesso ao array
            timer = anim_Speed;
            }
    }


    private void ResetAnimation()
    {
        if(spriteArray.Length > 0)
        {
            enabled = true;
            ref_Image.sprite = spriteArray[0];
        }
        
        timer = anim_Speed;
    }

}
