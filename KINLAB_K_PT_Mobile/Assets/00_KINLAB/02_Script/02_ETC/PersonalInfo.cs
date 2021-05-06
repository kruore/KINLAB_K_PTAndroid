using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _KINLAB
{
    public class PersonalInfo : MonoBehaviour
    {
        public static PersonalInfo instance = null;

        private string userName;
        public string UserName { get { return userName; } set { userName = value; } }
        private string userInternalID;
        public string UserInternalID { get { return userInternalID; } set { userInternalID = value; } }

        //------------

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}