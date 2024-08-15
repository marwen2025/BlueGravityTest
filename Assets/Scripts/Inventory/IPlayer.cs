using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayer
{
    public void HealPlayer(float amount);
    public float Health { get; set; }
}
