using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemySkill
{
    // �ΰ��� �̻����� ��ų �Լ� ������ ������ ��쿡�� ����ġ ������ �̿��� ��ų�� ����ϵ��� �Ѵ�.
    // WeakSkill = 3; MiddleSkill = 2; SpecialMove = 1; �� Weight�� �ش�.

    // ���� ���. �� �i�ư��� �����ϴ� ���� �����ϰ� �׳� ��Ÿ. �����ϴ� ���� �����ϸ� ���� �� �̰Ŵ� ������ �־����.
    void WeakSkill();

    // �߰� ���. �� ��. ���� ������ �߻����� �������� ���� ������ �ٿ� �� ��ü������ ������
    void MiddleSkill();

    // �ʻ��. ���� ��. ������ �������� ����� ������
    void SpecialMove();
}
