using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.OneVsOne.Player.Detectors
{
    [RequireComponent(typeof(Transform))]

    public class HitableDetector : MonoBehaviour {
        public Transform hitableDetector;
        public float radiusDetection;
        public LayerMask whatIsHitable;

        [HideInInspector]
        public bool canHit = false;

        [HideInInspector]
        public float direction;

        [HideInInspector]
        public GameObject ojectForHit;
        public GameObject Parent;

        void FixedUpdate ()
        {
            this.CheckOverlap ();
        }

        private void CheckOverlap ()
        {
            this.canHit = false;
            this.ojectForHit = null;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(this.hitableDetector.position, this.radiusDetection, this.whatIsHitable);
            if (colliders.Length > 1)
            {
                this.FindeNearest (colliders);
            } 
        }

        private void FindeNearest (Collider2D[] colliders)
        {
            float distance = 1000;
            GameObject go = null;

            for (int i = 0; i < colliders.Length; i++){
                float tempDistance = Vector2.Distance(this.transform.position, colliders[i].transform.position);
                
                if (tempDistance < distance && colliders[i].gameObject != this.Parent){
                    distance = tempDistance;
                    go = colliders[i].gameObject;
                } 
            }

            if (go != null){
                float deltaX = go.transform.position.x - this.transform.position.x;
                this.UpdateValues(go, true, deltaX);
            }
        }

        private void UpdateValues (GameObject go, bool canHit, float deltaX)
        {
            this.ojectForHit = go;
            this.canHit = canHit;
            this.direction = Mathf.Sign(deltaX);
        }
    }

}
