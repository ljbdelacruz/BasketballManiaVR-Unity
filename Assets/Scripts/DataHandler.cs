using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class DataHandler:MonoBehaviour {

    public PlayerStats stats;
    public int storeCount=0;
    void Start() {
        stats = new PlayerStats();
    }
    public Status LoadDataPlayer() {
        FileStream file = null;
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            stats = (PlayerStats)bf.Deserialize(file);
            return this.AssignStatus(stats, 1);
        }
        catch(Exception e) {
            Debug.Log(e);
        }
        return this.AssignStatus(stats, 0);
    }
    public Status AssignStatus(PlayerStats stat, int option) {
        Status nStat = new Status();
        switch (option) {
            case 0:
                nStat.score = 0;
                nStat.gold = 0;
                break;
            case 1:
                nStat.score = stat.GetScore();
                nStat.gold = stat.GetGold();
                break;
        }
        return nStat;
    }
    public PlayerStats SetPlayerStat(Status data) {
        PlayerStats pStat = new PlayerStats();
        pStat.SetScore(data.score);
        pStat.SetGold(data.gold);
        return pStat;
    }
    public void StoreData(Status data) {
        this.storeCount++;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        try
        {
            
            bf.Serialize(file, SetPlayerStat(data));
        }
        catch (Exception e) { Debug.Log(e); }
        finally {
            if (file != null) {
                file.Close();
            }
        }
    }
    public void StoreData(PlayerStats pstat) {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        try
        {
            bf.Serialize(file, stats);
        }
        catch (Exception e){Debug.Log(e);}
        finally {
            if (file != null)
            {
                file.Close();
            }
        }
    }

    PlayerStats SetPlayerStats(Status stats) {
        PlayerStats temp = new PlayerStats();
        temp.SetScore(stats.score);
        temp.SetGold(stats.gold);
        return temp;
    }
    Status RetrievePlayerStats(PlayerStats stats) {
        Status data = new Status();
        data.score = stats.GetScore();
        return data;
    }
}
