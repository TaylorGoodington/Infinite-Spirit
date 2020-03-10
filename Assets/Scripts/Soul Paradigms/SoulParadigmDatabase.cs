using UnityEngine;
using System.Collections.Generic;
using static Utility;

public class SoulParadigmDatabase : MonoBehaviour {

	public static SoulParadigmDatabase Instance { get; set; }
	private List<SoulParadigm> SoulParadigms;

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
		SoulParadigms = new List<SoulParadigm>
		{
			new SoulParadigm (Paradigm.Trainee, "PLACEHOLDER", 3, 3, 3, 3, null, null),
			new SoulParadigm (Paradigm.Soldier, "PLACEHOLDER", 8, 4, 7, 5, new Paradigm[] { Paradigm.Trainee }, null),
			new SoulParadigm (Paradigm.Knight, "PLACEHOLDER", 12, 6, 10, 8, new Paradigm[] { Paradigm.Soldier }, null),
			new SoulParadigm (Paradigm.Paladin, "PLACEHOLDER", 24, 12, 20, 16, new Paradigm[] { Paradigm.Knight, Paradigm.Bishop }, new Paradigm[] { Paradigm.Bishop }),
			new SoulParadigm (Paradigm.Templar, "PLACEHOLDER", 39, 21, 33, 27, new Paradigm[] { Paradigm.Paladin, Paradigm.Sage }, new Paradigm[] { Paradigm.Sage }),
			new SoulParadigm (Paradigm.Priest, "PLACEHOLDER", 4, 5, 8, 7, new Paradigm[] { Paradigm.Trainee }, null),
			new SoulParadigm (Paradigm.Bishop, "PLACEHOLDER", 6, 8, 12, 10, new Paradigm[] { Paradigm.Priest }, null),
			new SoulParadigm (Paradigm.Sage, "PLACEHOLDER", 12, 16, 24, 20, new Paradigm[] { Paradigm.Bishop, Paradigm.Mage }, new Paradigm[] { Paradigm.Mage }),
			new SoulParadigm (Paradigm.Shaman, "PLACEHOLDER", 21, 27, 39, 33, new Paradigm[] { Paradigm.Sage, Paradigm.Sorceror }, new Paradigm[] { Paradigm.Sorceror }),
			new SoulParadigm (Paradigm.Wizard, "PLACEHOLDER", 5, 7, 4, 8, new Paradigm[] { Paradigm.Trainee }, null),
			new SoulParadigm (Paradigm.Mage, "PLACEHOLDER", 8, 10, 6, 12, new Paradigm[] { Paradigm.Wizard }, null),
			new SoulParadigm (Paradigm.Bard, "PLACEHOLDER", 16, 20, 12, 24, new Paradigm[] { Paradigm.Mage, Paradigm.Ranger }, new Paradigm[] { Paradigm.Ranger }),
			new SoulParadigm (Paradigm.Sorceror, "PLACEHOLDER", 27, 33, 21, 39, new Paradigm[] { Paradigm.Bard, Paradigm.Monk }, new Paradigm[] { Paradigm.Monk }),
			new SoulParadigm (Paradigm.Archer, "PLACEHOLDER", 7, 8, 5, 4, new Paradigm[] { Paradigm.Trainee }, null),
			new SoulParadigm (Paradigm.Ranger, "PLACEHOLDER", 10, 12, 8, 6, new Paradigm[] { Paradigm.Archer }, null),
			new SoulParadigm (Paradigm.Monk, "PLACEHOLDER", 20, 24, 16, 12, new Paradigm[] { Paradigm.Ranger, Paradigm.Knight }, new Paradigm[] { Paradigm.Knight }),
			new SoulParadigm (Paradigm.Duelist, "PLACEHOLDER", 33, 39, 27, 21, new Paradigm[] { Paradigm.Monk, Paradigm.Paladin }, new Paradigm[] { Paradigm.Paladin }),
			new SoulParadigm (Paradigm.Hero, "PLACEHOLDER", 54, 54, 54, 54, new Paradigm[] { Paradigm.Templar, Paradigm.Shaman, Paradigm.Sorceror, Paradigm.Duelist }, new Paradigm[] { Paradigm.Templar, Paradigm.Shaman, Paradigm.Sorceror, Paradigm.Duelist })
		};
	}
}

[System.Serializable]
public class SoulParadigm
{

	public Paradigm paradigm;
	public string description;
	public byte coreFirewall;
	public byte compiler;
	public byte defenseMatrix;
	public byte predictiveAlgorithms;
	public Paradigm[] requiredParadigms;
	public Paradigm[] additionalParadigmSkills;
	public Sprite icon;

	public SoulParadigm(Paradigm soulParadigm, string souldDescription, byte soulCoreFirewall, byte soulCompiler, byte soulDefenseMatrix,
		byte soulPredictiveAlgorithms, Paradigm[] soulRequiredParadigms, Paradigm[] skills)
	{
		paradigm = soulParadigm;
		description = souldDescription;
		coreFirewall = soulCoreFirewall;
		compiler = soulCompiler;
		defenseMatrix = soulDefenseMatrix;
		predictiveAlgorithms = soulPredictiveAlgorithms;
		requiredParadigms = soulRequiredParadigms;
		additionalParadigmSkills = skills;
		icon = Resources.Load<Sprite>("Paradigm Icons/" + soulParadigm);
	}
}