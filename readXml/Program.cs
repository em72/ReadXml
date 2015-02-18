using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace readXml
{
    class Program
    {
        static void Main(string[] args)
        {
            XElement root = XElement.Load("Courses.xml");
 
            // Find all elements of "Address" and select only elements where attribute Type is "Billing"
            IEnumerable<XElement> address = from el in root.Elements("Courses")
                                  //where (string)el.Attribute("Type") == "Billing"
                                  select el;

            List<course> courses = new List<course>();
            int raknare = 0;
            foreach (XElement elm in address)
            {
                raknare++;
                course course = new course();
                int id = 0;
                Int32.TryParse(elm.Element("ID").Value, out id);
                course.ID = id;

                course.Name = elm.Element("Name").Value;
                course.Code = elm.Element("Code").Value;
                
                int lengthInHours = 0;
                if(Int32.TryParse(elm.Element("LengthInHours").Value, out lengthInHours))
                    course.LengthInHours = lengthInHours;

                int GymnasiumPoints = 0;
                if(Int32.TryParse(elm.Element("GymnasiumPoints").Value, out GymnasiumPoints))
                    course.GymnasiumPoints = GymnasiumPoints;

                bool hasFinalExam = false;
                if(bool.TryParse(elm.Element("HasFinalExam").Value, out hasFinalExam))
                    course.HasFinalExam = hasFinalExam;

                int statusID = 0;
                if(Int32.TryParse(elm.Element("FK_Status_ID").Value, out statusID))
                    course.FK_Status_ID = statusID;

                int categoryID = 0;
                if(Int32.TryParse(elm.Element("FK_Category_ID").Value, out categoryID))
                    course.FK_Category_ID = categoryID;

                course.Objective = elm.Element("Objective").Value;
                course.ObjectiveLongDesc = elm.Element("ObjectiveLongDesc").Value;
                course.ContentDescription = elm.Element("ContentDescription").Value;
                course.Litterature = elm.Element("Litterature").Value;
                course.LitteratureReferences = elm.Element("LitteratureReferences").Value;
                course.RecommendedPrerequisites = elm.Element("RecommendedPrerequisites").Value;
                course.Prerequisites = elm.Element("Prerequisites").Value;

                //DateTime createdDT;
                //if(DateTime.TryParse(elm.Element("CreatedDT").Value, out createdDT))
                //    course.CreatedDT = createdDT;

                //DateTime deletedDT;
                //if (DateTime.TryParse(elm.Element("deletedDT").Value, out deletedDT))
                //    course.DeletedDT = deletedDT;
                
                course.strVersion = elm.Element("Version").Value;
                course.RetiredDT = elm.Element("RetiredDT").Value;

                int languageID = 0;
                if(Int32.TryParse(elm.Element("FK_Language_ID").Value, out languageID))
                    course.FK_Language_ID = languageID;

                course.GradingCriteria = elm.Element("GradingCriteria").Value;

                bool nationalCourse = false;
                if(bool.TryParse(elm.Element("NationalCourse").Value, out nationalCourse))
                    course.NationalCourse = nationalCourse;

                int gradeTypeID = 0;
                if(Int32.TryParse(elm.Element("FK_GradeType_ID").Value, out gradeTypeID))
                course.FK_GradeType_ID = gradeTypeID;

                int externalReferenceID = 0;
                if(Int32.TryParse(elm.Element("Exlearn1ReferenceID").Value, out externalReferenceID))
                course.Exlearn1ReferenceID = externalReferenceID;


                course.ShortName = elm.Element("ShortName").Value;

                bool isVux2012 = false;
                if(bool.TryParse(elm.Element("IsVux2012").Value, out isVux2012))
                    course.IsVux2012 = isVux2012;

                int externalContentID = 0;
                if(Int32.TryParse(elm.Element("ExternalContentID").Value, out externalContentID))
                course.ExternalContentID = externalContentID;

                bool externalContentEnabled = false;
                if(bool.TryParse(elm.Element("ExternalContentEnabled").Value, out externalContentEnabled))
                    course.ExternalContentEnabled = externalContentEnabled;

                Console.WriteLine(string.Format("{0};{1};{2};{3};{4};{5};{6}", course.Name, course.ID, course.Code, course.FK_Category_ID, course.FK_GradeType_ID, course.FK_Status_ID, course.ShortName));
                courses.Add(course);
            }
            Console.WriteLine(raknare);
            Console.ReadLine();
           
        }
    }

    public class course
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int LengthInHours { get; set; }
        public int GymnasiumPoints { get; set; }
        public bool HasFinalExam { get; set; }
        public int FK_Status_ID { get; set; }
        public int FK_Category_ID { get; set; }
        public string Objective { get; set; }
        public string ObjectiveLongDesc { get; set; }
        public string ContentDescription { get; set; }
        public string Litterature { get; set; }
        public string LitteratureReferences { get; set; }
        public string RecommendedPrerequisites { get; set; }
        public string Prerequisites { get; set; }
        public DateTime CreatedDT { get; set; }
        public DateTime DeletedDT { get; set; }
        public string strVersion { get; set; }
        public string RetiredDT { get; set; }
        public int FK_Language_ID { get; set; }
        public string GradingCriteria { get; set; }
        public bool NationalCourse { get; set; }
        public int FK_GradeType_ID { get; set; }
        public int Exlearn1ReferenceID { get; set; }
        public string ShortName { get; set; }
        public bool IsVux2012 { get; set; }
        public int ExternalContentID { get; set; }
        public bool ExternalContentEnabled { get; set; }

    }
}
