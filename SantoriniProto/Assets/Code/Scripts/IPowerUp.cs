using System;

public interface IPowerUp
{
    byte Attack(EnemyStatus entity);
    byte Defend();
}
