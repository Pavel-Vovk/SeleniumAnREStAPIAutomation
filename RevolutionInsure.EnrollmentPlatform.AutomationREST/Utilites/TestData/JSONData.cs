using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Schema.Generation;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace RevolutionInsure.EnrollmentPlatform.AutomationREST.Utilites.TestData
{
    public static class JSONData
    {
        private static string json;
        public static string GetEntityFromJSONFile(string entityName)
        {
            string path;
            ApplicationConfiguration appconfig = new ApplicationConfiguration("GeneralConfiguration", "Paths");
            path = appconfig.GetConfig()["JSONTestDataFilesPath"];
            json = File.ReadAllText(path + entityName + @".json");
            return json;
        }


        public static void LoadJSONDataToFile<T>(Object obj)
        {
            string path;
            ApplicationConfiguration appconfig = new ApplicationConfiguration("GeneralConfiguration", "Paths");
            path = appconfig.GetConfig()["JSONTestDataFilesPath"];
            if (isList(typeof(T)))
            {
                //string str = typeof(T).GetGenericTypeDefinition().Name;
                //str = Regex.Replace(str, @"\`\d+", "_of_");

                path = path + typeof(T).GetGenericArguments()[0].Name + "(s-es).json";
            }
            else
            {

                path = path + typeof(T).Name + ".json";
            }
            if (File.Exists(path))
            {
                if (! string.Equals(File.ReadAllText(path), JsonConvert.SerializeObject(obj)))
                {
                    File.WriteAllText(path, JsonConvert.SerializeObject(obj));
                }
            }
            else
            {
                File.WriteAllText(path, JsonConvert.SerializeObject(obj));
            }


        }




        /// <summary>
        /// Write on <JSONTestDataFilesPath>Schemas/ (from app.config) the schema of the type defined to <type>.jschema file
        /// if such schema exist - update it if some chages happened, if no - leave the existting file
        /// </summary>
        /// <param name="type">Type of of the Object for JSON Schema generation </param>
        public static void LoadJSONSchemaToFile(Type type)
        {
            string path;
            ApplicationConfiguration appconfig = new ApplicationConfiguration("GeneralConfiguration", "Paths");
            path = appconfig.GetConfig()["JSONTestDataFilesPath"];
            path = path + @"Schemas\" + type.Name + ".jschema";
            JSchemaGenerator generator = new JSchemaGenerator();
            JSchema schema = generator.Generate(type);
            if (File.Exists(path))
            {
                if (! string.Equals(File.ReadAllText(path), schema.ToString()))
                {
                    File.WriteAllText(path, schema.ToString());
                }
            }
            else
            {
                File.WriteAllText(path, schema.ToString());
            }
        }

        public static string GetEntityFromDB()
        {
            //TODO get data ftom DB
            return json;
        }


        public static string GetJsonFromObject(Type objectType, string inputStr)
        {
            try
            {
                TypeConverter typeConverter = TypeDescriptor.GetConverter(objectType);
                object value = typeConverter.ConvertFromString(inputStr);
                return JsonConvert.SerializeObject(value);
            }catch(Exception e)
            {
                return e.Message;
            }
        }

        private static bool isList(Type type)
        {
            return (type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(List<>)));
        }
    }
}
