using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKnockback // will allow us to define who can be knocked back 
{
    void Knockback(Vector2 direction, float power, float duration);


}
