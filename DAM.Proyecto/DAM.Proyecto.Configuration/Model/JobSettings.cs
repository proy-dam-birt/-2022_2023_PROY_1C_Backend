using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.Configuration.Model
{
    public class TriggerTime
    {
        public long? Hour { get; set; }

        public long? Minute { get; set; }
    }

    public class JobSettings
    {
        /// <summary>
        /// Job name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// job trigger time in case of on time triggered job 
        /// </summary>
        public TriggerTime TriggerTimeValue { get; set; }

        /// <summary>
        /// Period time (in second) in case of  simple triggered job
        /// </summary>
        public long? SimpleTriggerTime { get; set; }

        /// <summary>
        /// Flag with job activity 
        /// </summary>
        public bool Enabled { get; set; }

        public JobSettings(string name, TriggerTime? triggerTimeValue, long? simpleTriggerTime, bool enabled)
        {
            Name = name;
            TriggerTimeValue = triggerTimeValue;
            SimpleTriggerTime = simpleTriggerTime;
            Enabled = enabled;
        }
    }
}
