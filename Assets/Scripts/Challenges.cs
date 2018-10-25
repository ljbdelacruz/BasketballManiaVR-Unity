using UnityEngine;
using System.Collections;

public class Challenges : MonoBehaviour {
    public string winningCondition, awardName;
    public Status stats;

    public bool AccuracyTest(Status myStats) {
        if (myStats.GetAccuracyRate() >= this.stats.GetAccuracyRate() && myStats.score >= this.stats.score) {
            return true;
        }
        return false;
    }
    
}
