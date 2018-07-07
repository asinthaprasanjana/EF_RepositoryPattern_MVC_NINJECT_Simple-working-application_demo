using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntityManager;
using DataEntity;
using DataEntity.Repository;
using DTOs;
using AutoMapper;

namespace BusinessLogic
{
    public class StudentManagement:IStudentRepo
    {
        private readonly StudentRepository repository;
        public StudentManagement()
        {
            repository = new StudentRepository();
        }
        private readonly DataContext context = new DataContext();
        public IEnumerable<Student> Student
        {
            get
            {
                return context.Students;
            }
        }

        /// <summary>
        /// Get student By id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StudentDto Get_StudentBY_ID(int id)
        {
            try {
                var student = repository.GetStudent(id);
                return Mapper.Map<StudentDto>(student);
            }
            catch (Exception x)
            {
                throw new NullReferenceException("Student NOT found ",x);
            }
        }

        public Student SaveStudent(Student student)
        {            
                if (this.IsVlidStudent(student)==true) {
                var NewStudent = repository.Insert(student);
                return NewStudent;
            }
            else
            {
                throw new ArgumentNullException("Provided information is not valid.");
            }          
         }

   
        public Student DeleteStudent(int ID)
        {

            Student DelStudent = context.Students.SingleOrDefault(item => item.StudentId == ID);
            context.Students.Remove(DelStudent);
            context.SaveChanges();


            return null;
        }

        public Student UpdateStudent(Student Updatedstudent)
        {

            MapperDto_Class.ConfigAutoMapper();

            Student ExsistStudent = context.Students.SingleOrDefault(item => item.StudentId == Updatedstudent.StudentId);

            if (ExsistStudent != null)
            {
                ExsistStudent.Name = Updatedstudent.Name;
                ExsistStudent.Age = Updatedstudent.Age;
                ExsistStudent.createdby = Updatedstudent.createdby;
                ExsistStudent.modifiedby = Updatedstudent.modifiedby;
                ExsistStudent.modifieddate = Updatedstudent.modifieddate;

                repository.Update(Mapper.Map<Student>(Updatedstudent));               
            }

            return null;

        }

        private bool IsVlidStudent(Student student)
        {
            if (student==null)
            {
                throw new ArgumentNullException("NULL student reference");
            }

            if (string.IsNullOrEmpty(student.Name))
            {
                throw new ArgumentNullException("Name cannot be NULL ");
            }

            if (string.IsNullOrEmpty(student.Age.ToString()))
            {
                throw new ArgumentNullException("Age cannot be NULL ");
            }



            return true;
        }

     
    }
    
}
