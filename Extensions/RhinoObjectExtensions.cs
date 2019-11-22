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
            threeModel.data.attributes = new Attributes();
            

            var geo = rhinoObject.Geometry;

            if (geo.HasBrepForm)
            {
                Brep brep = Brep.TryConvertBrep(geo);

                Mesh[] meshes = Mesh.CreateFromBrep(brep, new MeshingParameters());
                Mesh mesh = null;

                if (meshes.Length > 1)
                {
                    Mesh meshfirst = meshes[0];
                    
                    for (int i = 1; i < meshes.Length; i++)
                    {
                        meshfirst.Append(meshes[i]);
                    }

                    mesh = meshfirst;
                }
                else
                {
                    mesh = meshes[0];
                }

                Rhino.RhinoDoc.ActiveDoc.Objects.AddMesh(mesh);
                
                mesh.Faces.ConvertQuadsToTriangles();


                double[] verticeArray = new double[(mesh.Faces.Count * 3) * 3];
                double[] normals = new double[(mesh.Faces.Count * 3) * 3];

                mesh.Normals.ComputeNormals();

                //int normCounter = 0;
                //foreach (var normy in mesh.Normals)
                //{
                //    normy.Unitize();
                //    normals[normCounter++] = normy.X;
                //    normals[normCounter++] = normy.Y;
                //    normals[normCounter++] = normy.Z;
                //}

                int counter = 0;

                foreach (MeshFace mface in mesh.Faces)
                {

                    normals[counter] = mesh.Normals[mface.A].X;
                    verticeArray[counter++] = mesh.Vertices[mface.A].X;
                    verticeArray[counter++] = mesh.Vertices[mface.A].Y;
                    verticeArray[counter++] = mesh.Vertices[mface.A].Z;

                    verticeArray[counter++] = mesh.Vertices[mface.B].X;
                    verticeArray[counter++] = mesh.Vertices[mface.B].Y;
                    verticeArray[counter++] = mesh.Vertices[mface.B].Z;

                    verticeArray[counter++] = mesh.Vertices[mface.C].X;
                    verticeArray[counter++] = mesh.Vertices[mface.C].Y;
                    verticeArray[counter++] = mesh.Vertices[mface.C].Z;
                }

                //foreach (Point3f vert in mesh.Vertices)
                //{
                //    verticeArray[counter++] = Math.Round(vert.X, 3);
                //    verticeArray[counter++] = Math.Round(vert.Y, 3);
                //    verticeArray[counter++] = Math.Round(vert.Z, 3); 
                //}

                threeModel.data.attributes.position = new AttributeObj()
                {
                    itemSize = 3,
                    type = "Float32Array",
                    array = verticeArray,
                };

                //threeModel.data.attributes.normal = new AttributeObj()
                //{
                //    itemSize = 3,
                //    type = "Float32Array",
                //    array = normals
                //};

                threeModel.data.boundingSphere = new BoundingSphere()
                {
                    center = new int[] { 0, 0, 0 },
                    radius = 1000,
                };
            }

            return threeModel;
        }
    }
}
