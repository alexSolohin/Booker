using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Rigidbody))]
public class PhysicsMorphAcceleration : MonoBehaviour {
    [SerializeField] private Morph morph;

    private static readonly int centerProperty = Shader.PropertyToID("_Center");
    private static readonly int deformationProperty = Shader.PropertyToID("_Deformation");

    private Material material;
    private Rigidbody body;

    private void Start() {
        material = GetComponent<MeshRenderer>().material;
        body = GetComponent<Rigidbody>();
        material.SetVector(centerProperty, morph.Center);
    }

    private void FixedUpdate() {
        if (morph.IsEnabled) {
            var velocityAtCenter = body.GetPointVelocity(transform.TransformPoint(morph.Center));
            var deformation = morph.UpdateDeformation(velocityAtCenter, Time.fixedDeltaTime);
            material.SetVector(deformationProperty, transform.InverseTransformDirection(deformation));
        }
    }

    [Serializable]
    public class Morph {
        [SerializeField] private bool isEnabled = false;
        [SerializeField] private Vector3 center = Vector3.zero;
        [SerializeField] private float deformationRate = 10;
        [SerializeField] private float relaxRate = 1000;
        [SerializeField] private float relaxDamping = 0.9f;

        private Vector3 previousVelocity;
        private Vector3 deformationVelocity;
        private Vector3 deformation;

        public Vector3 Center => center;
        public bool IsEnabled => isEnabled;

        public Vector3 UpdateDeformation(Vector3 velocityAtCenter, float deltaTime) {
            var acceleration = (velocityAtCenter - previousVelocity) / deltaTime;

            deformationVelocity += acceleration * deformationRate * deltaTime;
            deformationVelocity -= deformation * relaxRate * deltaTime;
            deformationVelocity *= relaxDamping;

            previousVelocity = velocityAtCenter;

            return deformation;
        }
    }
}
