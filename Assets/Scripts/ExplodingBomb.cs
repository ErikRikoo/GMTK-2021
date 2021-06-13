using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Triggerable.Trigger;

namespace Traps {
    public class ExplodingBomb : MonoBehaviour
    {
        [SerializeField] int m_ExplosionRadius;
        [SerializeField] private ColliderFilterSO m_ColliderFilter;
        [SerializeField] private GameObject m_ExplosionObject;
        

        public void OnTriggerEnter(Collider other) 
        {
            if (other.gameObject.GetComponent(typeof(CrowdEntity))) 
            {
                LayerMask CrabMask = LayerMask.GetMask("Crowd");
                Collider[] NearbyColliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius, CrabMask);
                Instantiate(m_ExplosionObject, transform.position, Quaternion.identity);

                foreach(Collider CrabCollider in NearbyColliders) 
                {
                    CrowdEntity CrabEntity = CrabCollider.gameObject.GetComponent(typeof(CrowdEntity)) as CrowdEntity;
                    CrabEntity.Die();
                }
            }
        }
    }

}