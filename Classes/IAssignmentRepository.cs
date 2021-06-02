using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class IAssignmentRepository
    {
        public AssignmentRepository assignmentRepository;
        public IAssignmentRepository(AssignmentRepository repo)
        {
            this.assignmentRepository = repo;
        }

        public List<DynamicAssignment> AccessAssignments { get => assignmentRepository.Assignments; set => assignmentRepository.Assignments = value; }
        public List<DynamicAssignment> GetAssignments()
        {
            return assignmentRepository.Assignments;
        }

        public void WriteToFile(List<DynamicAssignment> assignmentsInFile)
        {
            this.assignmentRepository.WriteToFile(assignmentsInFile);
        }

        public Boolean Create(DynamicAssignment newAssignment)
        {
            return this.assignmentRepository.Create(newAssignment);
        }

        public List<DynamicAssignment> PullFromFile()
        {
            return this.assignmentRepository.PullFromFile();
        }

        public List<DynamicAssignment> GetAll()
        {
            return this.assignmentRepository.GetAll();
        }

        public Boolean Delete(DynamicAssignment assignment)
        {
            return this.assignmentRepository.Delete(assignment);
        }

    }
}
