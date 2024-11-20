using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM : MonoBehaviour {
    public agentFSM fsm;
    public Transform playerAgent;

    Animator animator;
    public enum agentFSM {
        //IDLE
        IDLE_DOWN,
        IDLE_UP,
        IDLE_RIGHT,
        IDLE_LEFT,
        //MOVING
        MOVING_DOWN,
        MOVING_UP,
        MOVING_RIGHT,
        MOVING_LEFT,
        //ATTACKING
        ATTACKING_UP,
        ATTACKING_DOWN,
        ATTACKING_LEFT,
        ATTACKING_RIGHT,
        //SPRINTING
        SPRINT_DOWN,
        SPRINT_UP,
        SPRINT_RIGHT,
        SPRINT_LEFT,
        //carring
        CARRY_DOWN,
        CARRY_UP,
        CARRY_RIGHT,
        CARRY_LEFT,
        //dying
        DEATH
    }
    public enum agentEnemy {
        //STOP
        STOP,
        //MOVE
        MOVE_UP,
        MOVE_DOWN,
        MOVE_LEFT,
        MOVE_RIGHT,
        //ATTACK
        ATTACK,
        DIE //TODO: Complete the code to administate this new state
    }
    public void initializedStatesAgent() {
        switch (fsm) {

            case agentFSM.IDLE_DOWN:
            case agentFSM.IDLE_UP:
            case agentFSM.IDLE_RIGHT:
            case agentFSM.IDLE_LEFT:
                move();
                break;

            case agentFSM.MOVING_DOWN:
            case agentFSM.MOVING_UP:
            case agentFSM.MOVING_RIGHT:
            case agentFSM.MOVING_LEFT:
                move();
                break;

            case agentFSM.ATTACKING_DOWN:
            case agentFSM.ATTACKING_UP:
            case agentFSM.ATTACKING_RIGHT:
            case agentFSM.ATTACKING_LEFT:
                attack();
                break;

            case agentFSM.SPRINT_DOWN:
            case agentFSM.SPRINT_UP:
            case agentFSM.SPRINT_RIGHT:
            case agentFSM.SPRINT_LEFT:
                sprint();
                break;

            case agentFSM.CARRY_DOWN:
            case agentFSM.CARRY_UP:
            case agentFSM.CARRY_RIGHT:
            case agentFSM.CARRY_LEFT:
                carry();
                break;

            case agentFSM.DEATH:
                death();
                break;
        }
    }
    public void idle() {

    }
    public void move() {

    }
    public void attack() {

    }
    public void sprint() {

    }
    public void carry() {

    }
    public void death() {

    }
}

