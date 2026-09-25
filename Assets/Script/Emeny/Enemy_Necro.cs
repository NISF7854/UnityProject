using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Enemy_Necro : Enemy
{
    public necroIdleState idleState;
    public NecroCastingState castingState;
    public NecroBattleState battleState;
    public NecroDeadState deadState;



    //¼ì²âÍæ¼ÒÊÇ·ñÔÚ¹¥»÷·¶Î§ÄÚ
    public bool isPlayerInRange = false;


    protected override void Awake()
    {
        base.Awake();

        idleState = new necroIdleState(this, this, machine, "Idle");
        battleState = new NecroBattleState(this, this, machine, "Battle");
        castingState = new NecroCastingState(this, this, machine, "Casting");
        deadState = new NecroDeadState(this, this, machine, "Dead");
    }

    protected override void Start()
    {
        base.Start();
        machine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
    }
}
