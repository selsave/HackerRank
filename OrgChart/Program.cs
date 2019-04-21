using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgChart
{
    class Program
    {
        static List<Employee> employeesList = new List<Employee>();
        static int reportyCount = 0;
        static void Main(string[] args)
        {
            List<Employee> EmpList = new List<Employee>();

            EmpList.Add(new Employee { ID = "2", Name = "Sherly shar", ManagerID = "1" });
            EmpList.Add(new Employee { ID = "1", Name = "John crag", ManagerID = "-1" });
            EmpList.Add(new Employee { ID = "7", Name = "Thomas bhai", ManagerID = "-1" });
            EmpList.Add(new Employee { ID = "3", Name = "Nanacy james", ManagerID = "1" });
            EmpList.Add(new Employee { ID = "4", Name = "Robert hhh", ManagerID = "3" });
            EmpList.Add(new Employee { ID = "5", Name = "Micke ssss", ManagerID = "3" });
            EmpList.Add(new Employee { ID = "6", Name = "sak vell", ManagerID = "2" });
            EmpList.Add(new Employee { ID = "8", Name = "Patric Seawood", ManagerID = "3" });
            EmpList.Add(new Employee { ID = "9", Name = "Emly Skgulant", ManagerID = "3" });
            EmpList.Add(new Employee { ID = "10", Name = "Britne Bous", ManagerID = "9" });
            foreach (var emp in EmpList)
            {
                AddEmlployee(emp.ID, emp.Name, emp.ManagerID);
            }
            Print();
            Console.ReadLine();
            // Remove("3");
            // Move("3", "7");
            int res = Count("1");
            Console.WriteLine(  "Total Reporties = " + res);
            Console.ReadLine();
        }

        public static void AddEmlployee(string id, string name, string managerid)
        {
            employeesList.Add(new Employee { ID = id, Name = name, ManagerID = managerid });
        }
        public static void Print()
        {
            foreach (var emp in employeesList.Where(emp => emp.ManagerID == "-1"))
            {
                PrintEmployeeHirachi(emp.ID, emp.Name, 0);
            }
        }

        public static void Remove(string ID)
        {
            var currentEmp = employeesList.FirstOrDefault(emp => emp.ID == ID);
            if (currentEmp != null)
            {
                foreach (var reporties in employeesList.Where(emp => emp.ManagerID == ID))
                {
                    reporties.ManagerID = currentEmp.ManagerID;
                }
                employeesList.Remove(currentEmp);
            }
            Print();
        }

        //public static int Count(string ID, int reoortieCount)
        //{
        //    Console.WriteLine(reoortieCount);
        //    var currentEmp = employeesList.FirstOrDefault(emp => emp.ID == ID);
        //    if (currentEmp != null)
        //    {
        //        var repoties = employeesList.Where(em => em.ManagerID == ID);
        //        reoortieCount += repoties.Count();
        //        foreach (var rep in repoties)
        //        {
        //            Count(rep.ID, reoortieCount);
        //        }
        //    }

        //    return reoortieCount;
        //}

        public static int Count(string ID)
        {
            Console.WriteLine(reportyCount);
            var currentEmp = employeesList.FirstOrDefault(emp => emp.ID == ID);
            if (currentEmp != null)
            {
                var repoties = employeesList.Where(em => em.ManagerID == ID);
                reportyCount += repoties.Count();
                foreach (var rep in repoties)
                {
                    Count(rep.ID);
                }
            }

            return reportyCount;
        }

        public static void Move(string ID, string ManagerID)
        {
            var currentEmp = employeesList.FirstOrDefault(emp => emp.ID == ID);
            var ManagerEmp = employeesList.FirstOrDefault(emp => emp.ID == ManagerID);
            if (currentEmp != null && ManagerEmp != null)
            {
                currentEmp.ManagerID = ManagerID;
            }
            Print();
        }

        private static void PrintEmployeeHirachi(string iD, string name, int count)
        {
            Console.WriteLine(name + " [" + iD + "]");
            var repoties = employeesList.Where(em => em.ManagerID == iD);
            count++;
            foreach (var rep in repoties)
            {
                PrintEmployeeHirachi(rep.ID, addspace(count) + rep.Name, count);
            }
        }

        private static string addspace(int count)
        {
            StringBuilder spaceBuider = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                spaceBuider.Append("  ");
            }
            return spaceBuider.ToString();
        }
    }
}
