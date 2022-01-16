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

        public int EngineId { get => engineId; 
            set
            {
                engineId = value;
            }
        }
        public string EngineDescription { get => engineDescription;
            set
            {
                engineDescription = value;
                fullDescription = enginePower.ToString() + "L " + engineDescription;
                if (isAutomatic)
                    fullDescription += " Automatic";
                else
                    fullDescription += " Manual";
            }
        }
        public bool IsAutomatic { get => isAutomatic;
            set
            {
                isAutomatic = value;
                fullDescription = enginePower.ToString() + "L " + engineDescription;
                if (isAutomatic)
                    fullDescription += " Automatic";
                else
                    fullDescription += " Manual";
            }
        }

        public decimal EnginePower { get => enginePower; 
            set
            {
                enginePower = value;
                fullDescription = enginePower.ToString() + "L " + engineDescription;
                if (isAutomatic)
                    fullDescription += " Automatic";
                else
                    fullDescription += " Manual";
            }
        }
        public string FullDescription { get => fullDescription; }
    }
}
