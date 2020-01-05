﻿using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Domain.Models
{
    public class ApplicationModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ApplicationTypeID { get; set; }
        public int ThemeID { get; set; }
        public ApplicationModel() { }
        public ApplicationModel(Application application)
        {
            if(application != null)
            {
                ID = application.ID;
                Name = application.Name;
                Description = application.Description;
                ApplicationTypeID = application.ApplicationTypeID;
                ThemeID = application.ThemeID;
            }
        }
    }
}