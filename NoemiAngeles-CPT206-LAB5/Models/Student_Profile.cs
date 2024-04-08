using System.Xml.Linq;
namespace NoemiAngeles_CPT206_LAB5.Models
{
    public class Student_Profile
    {
        public class StudentProfile
        {
            public long Id { get; set; }
            public string? Name { get; set; }
            public double GPA { get; set; }
            public string? StudentEmail { get; set; }
            public string? Major { get; set; }
            public string? PhoneNumber { get; set; }
            public string? StudentUserName { get; set; }
            public string? password { get; set; }
            public string? hashedPassword { get; set; }
            public Boolean isVerified { get; set; }

        }
    }
}
