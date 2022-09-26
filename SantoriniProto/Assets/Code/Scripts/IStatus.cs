using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStatus
{
    void TakeDamage(byte damage);
    void DoDamage(IStatus damage);
}
