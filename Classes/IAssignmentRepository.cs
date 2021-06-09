using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public interface IAssignmentRepository
    {


        List<DynamicAssignment> Assignments { get; set; }


        void WriteToFile(List<DynamicAssignment> assignmentsInFile);


        Boolean Create(DynamicAssignment newAssignment);


        List<DynamicAssignment> PullFromFile();


        List<DynamicAssignment> GetAll();


        Boolean Delete(DynamicAssignment assignment);


    }
}
