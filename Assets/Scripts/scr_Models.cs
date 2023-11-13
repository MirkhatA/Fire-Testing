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

    public class ExtinguisherModel
    {
        
    }

    #endregion
}