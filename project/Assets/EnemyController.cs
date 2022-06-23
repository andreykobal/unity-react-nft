using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;



public class EnemyController : MonoBehaviour
{
    public Text m_MyText;

  public void SpawnEnemies (string amount) {
    Debug.Log ($"Spawning {amount} enemies!");
    StartCoroutine(GetText(amount));
  }

    
     // in javascript - when unity loaded - calls function in react - react->unity accountID -> calls our function GetText with account ID

    IEnumerator GetText(string accountID) {
        UnityWebRequest www = UnityWebRequest.Get($"https://filecoin-dlubh5ly6a-uc.a.run.app/owned/{accountID}"); //bobonspoge.near 
        // Check if NFT ID is from whitelisted NFTs - return foreverMediaId    -- if > 1 NFt in wallet from whitelist - random foreverMediaId
        // API call for forever media  https://filecoin-dlubh5ly6a-uc.a.run.app/fm/{foreverMediaId}
        // return forever media animation url and load it in TestAvatarLoader
        yield return www.SendWebRequest();
 
        if (www.result != UnityWebRequest.Result.Success) {
            Debug.Log(www.error);
        }
        else {
            // Show results as text
            Debug.Log(www.downloadHandler.text);
 
            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }
    }
    
    
}

