using dwweb_rhino.Models.Three;
using Rhino.DocObjects;
using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dwweb_rhino.Extensions
{
    public static class RhinoObjectExtensions
    {
        public static ThreeModel ToThreeJSGeometry(this RhinoObject rhinoObject)
        {
            ThreeModel threeModel = new ThreeModel();

            threeModel.metadata = new MetaData()
            {
                version = 4,
                type = "BufferGeometry",
                generator = "BufferGeometryExporter"
            };

            threeModel.data = new Data();
            

            var geo = rhinoObject.Geometry;

            if (geo.HasBrepForm)
            {
                Brep brep = (Brep)geo;

                Mesh mesh = Mesh.CreateFromBrep(brep, new MeshingParameters())[0];
                
                mesh.Faces.ConvertQuadsToTriangles();

                int[] verticeArray = new int[mesh.Faces.Count * 3];

                int counter = 0;

                foreach (Point3f vert in mesh.Vertices)
                {
                    verticeArray[counter++] = (int)(vert.X);
                    verticeArray[counter++] = (int)(vert.Y);
                    verticeArray[counter++] = (int)(vert.Z);
                }

                threeModel.data.attributes.position = new AttributeObj()
                {
                    itemSize = 3,
                    type = "Float32Array",
                    array = verticeArray,
                };

                threeModel.data.boundingSphere = new BoundingSphere()
                {
                    center = new int[] { 0, 0, 0 },
                    radius = 100,
                };
            }

            return threeModel;
        }
    }
}
