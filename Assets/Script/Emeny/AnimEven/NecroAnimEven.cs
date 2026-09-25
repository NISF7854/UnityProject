using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecroAnimEven : MonoBehaviour
{

    Enemy_Necro necro;
    [SerializeField] GameObject ballPrefab;

    // Start is called before the first frame update
    void Start()
    {
        necro = GetComponentInParent<Enemy_Necro>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShootTrigger()
    {
        GameObject ball = Instantiate(ballPrefab, new Vector2(necro.transform.position.x + 1.0f, necro.transform.position.y + 3.5f), necro.transform.rotation);
        ball.GetComponent<NecroBallController>().SetUp(necro);
    }

    public void FinishShootTrigger()
    {
        necro.machine.ChangeState(necro.battleState);
    }

}
