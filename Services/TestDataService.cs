using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dwweb_rhino.Models;
using Rhino;
using Rhino.DocObjects;

namespace dwweb_rhino.Services
{
    public class TestDataService : IDataService
    {
        public TestDataService()
        {
        }

        public Project GetProjectData()
        {
            RhinoDoc doc = RhinoDoc.ActiveDoc;

            Project project = new Project();

            project.Name = doc.Name;
            project.Id = Guid.NewGuid(); //Store on RhinoDoc User Text
            project.UserId = DwwebRhinoPlugin.Instance.LoggedInUser.Id;

            project.Objects = new List<AttributedObject>();

            var objects = RhinoDoc.ActiveDoc.Objects.GetObjectList(ObjectType.AnyObject);

            foreach (RhinoObject rObj in objects)
            {
                if (!rObj.HasUserData)
                    continue;

                AttributedObject aObj = new AttributedObject()
                {
                    Type = rObj.ObjectType.ToString()
                };

                aObj.Parameters = new List<Parameter>();

                foreach (string key in rObj.Attributes.UserDictionary.Keys)
                {
                    aObj.Parameters.Add(new Parameter()
                    {
                        Name = key,
                        Value = rObj.Attributes.UserDictionary[key].ToString()
                    });
                }

                project.Objects.Add(aObj);
            }

            return project;
        }
    }
}
