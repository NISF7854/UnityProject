using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAnimEven : MonoBehaviour
{
    [SerializeField]public GameObject arrowPrefab;
    Enemy_Archer archer;


    // Start is called before the first frame update
    void Start()
    {
        archer = GetComponentInParent<Enemy_Archer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShootTriiger()
    {
        
        GameObject arrow = Instantiate(arrowPrefab, new Vector2(archer.transform.position.x, archer.transform.position.y+1.5f), archer.transform.rotation);
        arrow.GetComponent<ArrowController>().SetUp(archer.facingDir * 10.0f,archer);
    }

    public void FinishShoot()
    {
        archer.machine.ChangeState(archer.idleState);
        archer.attackTimer = archer.attackClamdown;
    }

}
