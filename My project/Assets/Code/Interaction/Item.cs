using UnityEngine;

[System.Serializable]
public class Item : IItem
{
	[field: SerializeField]
	public int ID { get; set; }
	[field: SerializeField]
	public string Name { get; set; }
	[field: SerializeField]
	public string Description { get; set; }
	[field: SerializeField]
	public float Weight { get; set; }
	[field: SerializeField]
	public int Count { get; set; }
	[field: SerializeField]
	public bool isUnique { get; set; }

	public float TotalWeight
	{
		get { return Weight * Count; }
	}
}
