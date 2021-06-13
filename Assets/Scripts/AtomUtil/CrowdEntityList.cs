using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityEngine;

[CreateAssetMenu(fileName = "CrowdEntityList", menuName = "CrowdEntityList")]
public class CrowdEntityList : AtomValueList<CrowdEntity, AtomEvent<CrowdEntity>>
{

}
