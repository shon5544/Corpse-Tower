using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemySkill
{
    // 두가지 이상으로 스킬 함수 내용을 가지는 경우에는 가중치 랜덤을 이용해 스킬을 사용하도록 한다.
    // WeakSkill = 3; MiddleSkill = 2; SpecialMove = 1; 로 Weight를 준다.

    // 약한 기술. 걍 쫒아가서 몸빵하는 것을 제외하고 그냥 평타. 몸빵하는 몹을 제외하면 전부 다 이거는 가지고 있어야함.
    void WeakSkill();

    // 중간 기술. 쫌 쎔. 지금 당장은 추상적인 말이지만 점점 가지를 붙여 더 구체적으로 만들어보자
    void MiddleSkill();

    // 필살기. 존나 쎔. 맞으면 개손해인 기술로 만들자
    void SpecialMove();
}
