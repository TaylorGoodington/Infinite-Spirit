using UnityEngine;
using System.Collections.Generic;

public class AllyPersonalityDatabase : MonoBehaviour
{
	public static AllyPersonalityDatabase Instance { get; set; }
	public List<AllyPersonality> AllyPersonalities;

	void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(this.gameObject);
			return;
		}
		else
		{
			Instance = this;
		}
	}

	void Start()
	{
		AllyPersonalities = new List<AllyPersonality>
		{
			new AllyPersonality (2, 30f, 12f, 18f, 20f, 5f, 15f),
			new AllyPersonality (3, 35f, 5f, 25f, 5f, 25f, 5f)
		};
	}
}

[System.Serializable]
public class AllyPersonality
{

	public int characterId;
	public float patience;
	public float something;
	public float cunning;
	public float logical;
	public float kindness;
	public float charisma;

	public AllyPersonality(int characterId, float patience, float something, float cunning, float logical, float kindness, float charisma)
	{
		this.characterId = characterId;
		this.patience = patience;
		this.something = something;
		this.cunning = cunning;
		this.logical = logical;
		this.kindness = kindness;
		this.charisma = charisma;
	}
}