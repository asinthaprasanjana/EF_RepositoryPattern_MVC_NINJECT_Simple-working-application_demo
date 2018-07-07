using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using DataEntity.Repository;
using DataEntityManager;
using AutoMapper;

namespace BusinessLogic
{
  
    public class StudentMarkManagement: Repository<Marks>
    {
        private readonly MarksRepository repository;

        public StudentMarkManagement()
        {
             repository = new MarksRepository();
        }

        public MarksDto Add_Mark(MarksDto marks)
        {
            MapperDto_Class.ConfigAutoMapper();

            if (this.IsValidmark(marks)) {

                var NewMARK = repository.Insert(Mapper.Map<Marks>(marks));

                return Mapper.Map<MarksDto>(NewMARK);
            }
            else
            {
                throw new ArgumentNullException("Provided information is not valid.");
            }
        }

        private bool IsValidmark(MarksDto marks)
        {

            if (marks==null)
            {
                throw new ArgumentNullException("Null reference ");
            }

            if (string.IsNullOrEmpty(marks.Maths.ToString()))
            {
                throw new ArgumentNullException("Maths:validation error");
            }
            if (string.IsNullOrEmpty(marks.Science.ToString()))
            {
                throw new ArgumentNullException("Science:validation error");
            }

            if (string.IsNullOrEmpty(marks.Language.ToString()))
            {
                throw new ArgumentNullException("Language:validation error");
            }

            return true;
        }
    }
}
