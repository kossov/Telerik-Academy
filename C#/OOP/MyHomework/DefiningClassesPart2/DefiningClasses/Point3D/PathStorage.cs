namespace DefiningClasses
{
    using System;
    using System.IO;

    public static class PathStorage
    {
        public static void SavePath(Path path)
        {
            string filePath = @"..\..\MyTextFile.txt";
            using (StreamWriter myWriter = new StreamWriter(filePath))
            {
                myWriter.Write(path);
            }
        }

        public static Path LoadPath()
        {
            
            Path path = new Path();

            string filePath = @"..\..\MyTextFile.txt";
            using (StreamReader myReader = new StreamReader(filePath))
            {
                string[] allPaths = myReader.ReadToEnd().Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string onePath in allPaths)
                {
                    string[] xYandZ = onePath.Trim(new char[] { '[', ']' }).Split(new char[] { ',' },StringSplitOptions.RemoveEmptyEntries);
                    path.MyPath.Add(new Point3D(Convert.ToDouble(xYandZ[0]), Convert.ToDouble(xYandZ[1]), Convert.ToDouble(xYandZ[2])));
                }
            }
            return path;
        }
    }
}
