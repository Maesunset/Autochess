using UnityEngine;

public class BobIdleCondition : BobBaseCondition
{
    public override bool Check(BobStateMachine stateMachine)
    {
        return false;
    }
}
