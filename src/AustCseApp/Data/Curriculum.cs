using System.Collections.Generic;
using AustCseApp.Models;

namespace AustCseApp.Data
{
    /// <summary>
    /// Fixed course plan for AUST CSE.
    /// Key format: "Y{year}S{semester}" e.g., "Y1S1".
    /// </summary>
    public static class Curriculum
    {
        public static string Key(int year, int sem) => $"Y{year}S{sem}";

        public static readonly Dictionary<string, List<Course>> Courses = new()
        {
            // =========================== YEAR 1 • SEM 1 ===========================
            [Key(1, 1)] = new List<Course>
            {
                new Course { Code = "CHEM-1115", Title = "Chemistry",                                         Credit = 3.0 },
                new Course { Code = "CSE-1101",  Title = "Elementary Structured Programming",                 Credit = 3.0 },
                new Course { Code = "CSE-1102",  Title = "Elementary Structured Programming Lab",             Credit = 1.5 },
                new Course { Code = "CSE-1108",  Title = "Introduction to Computer Systems",                  Credit = 1.5 },
                new Course { Code = "HUM-1107",  Title = "Critical Thinking and Communication",               Credit = 3.0 },
                new Course { Code = "HUM-1108",  Title = "English Language Sessional",                        Credit = 1.5 },
                new Course { Code = "MATH-1115", Title = "Differential Calculus and Coordinate Geometry",     Credit = 3.0 },
                new Course { Code = "PHY-1115",  Title = "Physics",                                           Credit = 3.0 },
                new Course { Code = "PHY-1116",  Title = "Physics Lab",                                       Credit = 0.75 },
            },

            // =========================== YEAR 1 • SEM 2 ===========================
            [Key(1, 2)] = new List<Course>
            {
                new Course { Code = "CSE-1200",  Title = "Software Development–I",                            Credit = 1.5 },
                new Course { Code = "CSE-1203",  Title = "Discrete Mathematics",                              Credit = 3.0 },
                new Course { Code = "CSE-1205",  Title = "Object Oriented Programming",                       Credit = 3.0 },
                new Course { Code = "CSE-1206",  Title = "Object Oriented Programming Lab",                   Credit = 1.5 },
                new Course { Code = "EEE-1241",  Title = "Basic Electrical Engineering",                      Credit = 3.0 },
                new Course { Code = "EEE-1242",  Title = "Basic Electrical Engineering Lab",                  Credit = 1.5 },
                new Course { Code = "MATH-1219", Title = "Integral Calculus and Differential Equations",      Credit = 3.0 },
                new Course { Code = "ME-1211",   Title = "Basic Mechanical Engineering",                      Credit = 3.0 },
                new Course { Code = "ME-1214",   Title = "Engineering Drawing",                               Credit = 0.75 },
            },

            // =========================== YEAR 2 • SEM 1 ===========================
            [Key(2, 1)] = new List<Course>
            {
                new Course { Code = "CSE-2100",  Title = "Software Development–II",                           Credit = 0.75 },
                new Course { Code = "CSE-2103",  Title = "Data Structures",                                   Credit = 3.0 },
                new Course { Code = "CSE-2104",  Title = "Data Structures Lab",                               Credit = 1.5 },
                new Course { Code = "CSE-2105",  Title = "Digital Logic Design",                              Credit = 3.0 },
                new Course { Code = "CSE-2106",  Title = "Digital Logic Design Lab",                          Credit = 1.5 },
                new Course { Code = "EEE-2141",  Title = "Electronic Devices and Circuits",                   Credit = 3.0 },
                new Course { Code = "EEE-2142",  Title = "Electronic Devices and Circuits Lab",               Credit = 1.5 },
                new Course { Code = "HUM-2109",  Title = "Society, Ethics and Technology",                     Credit = 2.0 },
                new Course { Code = "MATH-2101", Title = "Complex Variable, Laplace Transformation and Statistics", Credit = 3.0 },
            },

            // =========================== YEAR 2 • SEM 2 ===========================
            [Key(2, 2)] = new List<Course>
            {
                new Course { Code = "CSE-2200",  Title = "Software Development–III",                          Credit = 0.75 },
                new Course { Code = "CSE-2201",  Title = "Numerical Methods",                                 Credit = 3.0 },
                new Course { Code = "CSE-2202",  Title = "Numerical Methods Lab",                             Credit = 0.75 },
                new Course { Code = "CSE-2207",  Title = "Algorithms",                                        Credit = 3.0 },
                new Course { Code = "CSE-2208",  Title = "Algorithms Lab",                                    Credit = 1.5 },
                new Course { Code = "CSE-2211",  Title = "Data Communication",                                Credit = 3.0 },
                new Course { Code = "CSE-2213",  Title = "Computer Architecture",                             Credit = 3.0 },
                new Course { Code = "CSE-2214",  Title = "Assembly Language Programming",                      Credit = 1.5 },
                new Course { Code = "MATH-2203", Title = "Matrix, Vector Analysis and Fourier Transformation", Credit = 3.0 },
            },

            // =========================== YEAR 3 • SEM 1 ===========================
            [Key(3, 1)] = new List<Course>
            {
                new Course { Code = "CSE-3100",  Title = "Software Development–IV",                           Credit = 0.75 },
                new Course { Code = "CSE-3101",  Title = "Mathematical Analysis for Computer Science",        Credit = 3.0 },
                new Course { Code = "CSE-3103",  Title = "Database",                                          Credit = 3.0 },
                new Course { Code = "CSE-3104",  Title = "Database Lab",                                      Credit = 1.5 },
                new Course { Code = "CSE-3109",  Title = "Digital System Design",                             Credit = 3.0 },
                new Course { Code = "CSE-3110",  Title = "Digital System Design Lab",                         Credit = 0.75 },
                new Course { Code = "CSE-3117",  Title = "Microprocessors and Microcontrollers",              Credit = 3.0 },
                new Course { Code = "CSE-3118",  Title = "Microprocessors and Microcontrollers Lab",          Credit = 0.75 },
                new Course { Code = "HUM-3115",  Title = "Economics and Accounting",                          Credit = 3.0 },
            },

            // =========================== YEAR 3 • SEM 2 ===========================
            [Key(3, 2)] = new List<Course>
            {
                new Course { Code = "CSE-3200",  Title = "Software Development–V",                            Credit = 0.75 },
                new Course { Code = "CSE-3201",  Title = "Introduction to Computer Networks",                 Credit = 3.0 },
                new Course { Code = "CSE-3202",  Title = "Introduction to Computer Networks Lab",             Credit = 0.75 },
                new Course { Code = "CSE-3207",  Title = "Introduction to Artificial Intelligence",           Credit = 3.0 },
                new Course { Code = "CSE-3208",  Title = "Introduction to Artificial Intelligence Lab",       Credit = 0.75 },
                new Course { Code = "CSE-3213",  Title = "Operating System",                                  Credit = 3.0 },
                new Course { Code = "CSE-3214",  Title = "Operating System Lab",                              Credit = 0.75 },
                new Course { Code = "CSE-3223",  Title = "Information System Design and Software Engineering", Credit = 3.0 },
                new Course { Code = "CSE-3224",  Title = "Information System Design and Software Engineering Lab", Credit = 0.75 },
                new Course { Code = "HUM-3207",  Title = "Industrial Law and Safety Management",              Credit = 3.0 },
            },

            // =========================== YEAR 4 • SEM 1 ===========================
            [Key(4, 1)] = new List<Course>
            {
                new Course { Code = "CSE-4113",  Title = "Pattern Recognition and Machine Learning",          Credit = 3.0 },
                new Course { Code = "CSE-4114",  Title = "Pattern Recognition and Machine Learning Lab",      Credit = 0.75 },
                new Course { Code = "CSE-4129",  Title = "Formal Languages and Compilers",                    Credit = 3.0 },
                new Course { Code = "CSE-4130",  Title = "Formal Languages and Compilers Lab",                Credit = 0.75 },
                new Course { Code = "CSE-4137",  Title = "Soft Computing",                                    Credit = 3.0 },
                new Course { Code = "CSE-4138",  Title = "Soft Computing Lab",                                Credit = 0.75 },
                new Course { Code = "CSE-4141",  Title = "Data Warehousing and Mining",                       Credit = 3.0 },
                new Course { Code = "CSE-4142",  Title = "Data Warehousing and Mining Lab",                   Credit = 0.75 },
                new Course { Code = "CSE-4173",  Title = "Cyber Security",                                    Credit = 3.0 },
                new Course { Code = "CSE-4174",  Title = "Cyber Security Lab",                                Credit = 0.75 },
                new Course { Code = "IPE-4111",  Title = "Industrial Management",                             Credit = 3.0 },
            },

            // =========================== YEAR 4 • SEM 2 ===========================
            [Key(4, 2)] = new List<Course>
            {
                new Course { Code = "CSE-4203",  Title = "Computer Graphics",                                 Credit = 3.0 },
                new Course { Code = "CSE-4204",  Title = "Computer Graphics Lab",                             Credit = 0.75 },
                new Course { Code = "CSE-4227",  Title = "Digital Image Processing",                          Credit = 3.0 },
                new Course { Code = "CSE-4228",  Title = "Digital Image Processing Lab",                      Credit = 0.75 },
                new Course { Code = "CSE-4261",  Title = "Data Analytics",                                    Credit = 3.0 },
                new Course { Code = "CSE-4262",  Title = "Data Analytics Lab",                                Credit = 0.75 },
                new Course { Code = "CSE-4263",  Title = "Internet of Things",                                Credit = 3.0 },
                new Course { Code = "CSE-4264",  Title = "Internet of Things Lab",                            Credit = 0.75 },
                new Course { Code = "CSE-4267",  Title = "Cloud Computing",                                   Credit = 3.0 },
            }
        };
    }
}
