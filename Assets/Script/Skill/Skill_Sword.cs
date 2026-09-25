using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Sword : Skill
{
    [Header("Skill Info")]
    [SerializeField] private GameObject swordPrefab;
    [SerializeField] private Vector2 launchForce;
    [SerializeField] private float swordGravity;

    private Vector2 finaDir;

    [Header("Aim dots")]
    [SerializeField] private int numberOfDots;
    [SerializeField] private float spaceBetweenDots;
    [SerializeField] private GameObject dotPrefab;
    [SerializeField] private Transform dotsParent;
    private GameObject[] dots;

    protected override void Start()
    {
        base.Start();
        GenerateDots();
    }


    protected override void Update()
    {


    }

    public void CreateSword()
    {
        GameObject newSword = Instantiate(swordPrefab, player.transform.position, transform.rotation);
        newSword.GetComponent<SkillSwordController>().SetupSword(new Vector2(launchForce.x*player.facingDir, 0), swordGravity);
        //DotsActive(false);
        player.AssignMewSword(newSword);
    }

    public Vector2 AimDirection()
    {
        Vector2 playerPosition = player.transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - playerPosition;
        return direction;
    }

    public void DotsActive(bool isActive)
    {
        for (int i = 0; i < numberOfDots; i++)
        {
            dots[i].SetActive(isActive);
        }
    }

    private void GenerateDots()
    {
        dots = new GameObject[numberOfDots];
        for(int i = 0; i < numberOfDots; i++) 
        {
            dots[i] = Instantiate(dotPrefab, player.transform.position, Quaternion.identity,dotsParent);
            dots[i].SetActive(false);
        }
    }

    private Vector2 DotsPosistion(float t)
    {
        Vector2 position = (Vector2)player.transform.position+new Vector2(AimDirection().normalized.x
            *launchForce.x,AimDirection().normalized.y*launchForce.y)*t+0.5f*(Physics2D.gravity*swordGravity
            *t*t);
        return position;
    }


}
