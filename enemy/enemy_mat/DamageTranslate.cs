using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTranslate : MonoBehaviour
{
    public Enemy_Health enemy;
    
    public void TraslateDamage (int Damage) {
        if (!enemy) return;
        enemy.DealDamageToEnemy(Damage);
    }
}
