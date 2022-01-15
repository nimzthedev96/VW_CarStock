using System;
using System.Collections.Generic;
using System.Text;

namespace VW_CarStock_Classes.Models
{
    public struct CarEngineType
    {
        private int engineId;
        private string engineDescription;
        private string fullDescription;
        private bool isAutomatic;
        private decimal enginePower;

        public int EngineId { get => engineId; set => engineId = value; }
        public string EngineDescription { get => engineDescription; set => engineDescription = value; }
        public bool IsAutomatic { get => isAutomatic; set => isAutomatic = value; }
        public decimal EnginePower { get => enginePower; set => enginePower = value; }
        public string FullDescription { get => fullDescription; set => fullDescription = value; }
    }
}
