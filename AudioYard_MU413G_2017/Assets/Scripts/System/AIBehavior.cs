using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.ThirdPerson
{

    public class AIBehavior : MonoBehaviour
    {
        private AICharacterControl charScript;
		public int hitpoints = 1;
		[HideInInspector]
		public AudioManager audioManager;

        void Awake()
        {
			if (hitpoints == 0)
			{
				hitpoints = 1;
			}
            charScript = gameObject.GetComponent<AICharacterControl>();
            charScript.target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
			audioManager = GameObject.FindObjectOfType<AudioManager> ();
        }

		void Start()
		{
			audioManager.MovingNPCSpawned ();
		}

		void Update()
		{
			if (hitpoints > 0) {
				return;
			}
			else if (hitpoints <= 0)
			{
				audioManager.MovingNPCDied ();
				Destroy(gameObject);
			}
		}

        void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.tag == "Player")
            {
            	other.gameObject.GetComponent<Player>().Death();
				audioManager.MovingNPCKilledplayer ();
				Destroy(gameObject);
            }
			if (other.gameObject.tag == "PlayerBullet")
			{
				hitpoints--;
				audioManager.MovingNPCHit (hitpoints);
			}

        }

    }
}