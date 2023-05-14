using LemonForest;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPage
{
    public PageEnum PageEnum { get; }
    public void FlipPage();
    public void Next();
    public void Previous();
    public void SetLayer(int i);


    public void DisableContent();
    public void EnableContent();
}
