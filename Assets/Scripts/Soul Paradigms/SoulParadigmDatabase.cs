using UnityEngine;
using System.Collections.Generic;
using static Utility;

public class SoulParadigmDatabase : MonoBehaviour {

	public static SoulParadigmDatabase Instance { get; set; }
	private List<SoulParadigm> SoulParadigms = new List<SoulParadigm>();

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

	void Start () 
	{
		SoulParadigms.Add (new SoulParadigm (Paradigm.Trainee, 3, 3, 3, 3, null));
	}
}

[System.Serializable]
public class SoulParadigm
{

	public Paradigm paradigm;
	public byte coreFirewall;
	public byte compiler;
	public byte defenseMatrix;
	public byte predictiveAlgorithms;
	public Paradigm[] requiredParadigms;

	public SoulParadigm(Paradigm soulParadigm, byte soulCoreFirewall, byte soulCompiler, byte soulDefenseMatrix, byte soulPredictiveAlgorithms, Paradigm[] soulRequiredParadigms)
	{
		paradigm = soulParadigm;
		coreFirewall = soulCoreFirewall;
		compiler = soulCompiler;
		defenseMatrix = soulDefenseMatrix;
		predictiveAlgorithms = soulPredictiveAlgorithms;
		requiredParadigms = soulRequiredParadigms;
	}
}