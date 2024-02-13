using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ModuleTopic
    {
        public int ModuleTopicID { get; set; }
        public int TopicID { get; set; }
        public int ModuleID { get; set; }

        public ModuleTopic()
        {

        }
        public ModuleTopic(int moduleTopicID,int topicID,int moduleID)
        {
            this.ModuleTopicID = moduleTopicID;
            this.ModuleID = moduleID;
            this.TopicID = topicID;
        }
    }
}
