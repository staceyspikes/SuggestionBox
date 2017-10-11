﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuggestionBox.Models
{
    public class SuggestionModel
    {
        private string topic;
        private string suggestion;
        private string name;

        [Key]
        public int RecordNum { get; set;}

        public string Topic
        {
            get { return this.topic; }
            set { this.topic = value; }
        }

        public string Suggestion
        {
            get { return this.suggestion; }
            set { this.suggestion = value; }
        }
        public string Name
        {
            get { return this.name;}
            set { this.name = value; }
        }

    
    }


}