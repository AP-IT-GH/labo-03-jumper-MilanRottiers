using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using Unity.Collections.LowLevel.Unsafe;
using System.Threading;
using JetBrains.Annotations;

public class CubeAgent : Agent
{
    public Rigidbody rb;
    public bool isGrounded;
    public float jumpForce;
    public bool lastActionWasJump = false;

    // Start wordt automatisch aangeroepen bij het starten van de episode
    public override void OnEpisodeBegin()
    {

        // Verwijder obstakels
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject obj in obstacles)
        {
            Destroy(obj);
        }

        // Reset de agent
        rb.velocity = Vector3.zero;
        transform.localPosition = new Vector3(0, 0.5f, 0); // Zet dit naar je gewenste startpositie
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // Geen vectorobservaties nodig
    }

    public void Good()
    {
        AddReward(1f);
    }
    public void Bad()
    {
        AddReward(-1f);
    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        int action = actions.DiscreteActions[0];


        if (action == 1 && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            lastActionWasJump = true;
        }
        else
        {
            lastActionWasJump = false;
        }
    }


    // Heuristic voor handmatige besturing (in de editor)
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var discreteActionsOut = actionsOut.DiscreteActions;
        discreteActionsOut[0] = Input.GetKey(KeyCode.Space) ? 1 : 0;
    }


    // Gebeurtenis bij botsing
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else if (collision.gameObject.name == "obstacle(Clone)")
        {
            Debug.Log("Hit an obstacle!");
            Destroy(collision.gameObject);
            SetReward(0f);
            EndEpisode();
        }
        else if (collision.gameObject.name == "bonusObstacle(Clone)")
        {
            Debug.Log("Hit a bonus obstacle!");
            Destroy(collision.gameObject);
            SetReward(1.0f);
            EndEpisode();
        }
    }



    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

}
