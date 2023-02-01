using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public float Weight { get; set; }
    public int Count { get; set; }
    public bool isUnique { get; set; }
    public float TotalWeight
    {
        get { return Weight * Count; }
    }



}
