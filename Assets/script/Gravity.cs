using System;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
   Rigidbody rb;
   const float G = 0.006674f;
   public static List<Gravity> planetLists;
   

   private void Awake()
   {
      rb = GetComponent<Rigidbody>();
      if (planetLists == null)
      {
         planetLists = new List<Gravity>();
      }
      planetLists.Add(this);
   }
   
   private void FixedUpdate()
   {
      foreach (var Planet in planetLists)
      {
         if(Planet != this)
             Attract(Planet);
      }
   }

   void Attract(Gravity other)
   {
      Rigidbody otherRb = other.rb;

      Vector3 direction = rb.position - otherRb.position;

      float distance = direction.magnitude;


      float forceMagnitude = G * (rb.mass * otherRb.mass) / Mathf.Pow(distance, 2);
      Vector3 finalForce = forceMagnitude * direction.normalized;
      
      otherRb.AddForce(finalForce);
   }
}
