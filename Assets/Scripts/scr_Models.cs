using System;
using System.Collections.Generic;
using UnityEngine;

public static class scr_Models
{
    #region Player

    [Serializable]
    public class PlayerModel
    {
        [Header("View Settings")] 
        public float ViewSensitivity;

        [Header("Movement")] 
        public float WalkingSpeed;
        public float StrafeSpeed;
    }    

    #endregion

    #region Extinguisher

    [Serializable]
    public class ExtinguisherModel
    {
        [Header("Extinguisher status"), Range(0f, 1f)] 
        public float CurrentIntensity = 0f;
    }

    #endregion

    #region Fire

    [Serializable]
    public class FireModel
    {
        [Header("Fire status"), Range(0f, 1f)] 
        public float FireIntensity = 1f;
        
    }

    #endregion
}
