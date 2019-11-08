using dwweb_rhino.Views;
using Rhino;
using Rhino.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dwweb_rhino
{
    public class dwwebRhinoCommand : Command
    {
        public dwwebRhinoCommand()
        {
            // Rhino only creates one instance of each command class defined in a
            // plug-in, so it is safe to store a refence in a static property.
            Instance = this;
        }

        ///<summary>The only instance of this command.</summary>
        public static dwwebRhinoCommand Instance
        {
            get; private set;
        }

        ///<returns>The command name as it appears on the Rhino command line.</returns>
        public override string EnglishName
        {
            get { return "DWWeb"; }
        }

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {

            Login loginView = new Login();
            loginView.Show();

            return Result.Success;
        }
    }
}
