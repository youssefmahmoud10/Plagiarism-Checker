using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopyCheck_v2
{
    public class DocumentClass
    {
        public DocumentClass(int id, string name, string content)
        {
            this.ID = id;
            this.Name = name;
            this.Content = content;
        }
        protected int ID { get; set; }
        protected string Name { get; set; }
        protected string Content { get; set; }
        protected double jacc_index {get; set;}
        protected double cos_index { get; set;}
        public double getJacc_index() 
        {
            return jacc_index;
        }
        public void setJacc_index(double jacc_index) 
        {
            this.jacc_index = jacc_index;
        }
        public string getContent() 
        {
            return this.Content;
        }
        public void setCos_index(double cos_index) 
        {
            this.cos_index = cos_index;
        }
        public double getCos_index() 
        {
            return cos_index;
        }
    }
}