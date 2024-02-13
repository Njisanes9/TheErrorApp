using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Topics
    {
        public string TopicDescription { get; set; }
        public int ErrorID { get; set; }
        public int TopicID { get; set; }
        public Topics()
        {

        }
        public Topics(int errorID,string topicDescription, int topicID)
        {
            this.TopicDescription = topicDescription;
            this.ErrorID = errorID;
            this.TopicID = topicID;
        }

    }


}
