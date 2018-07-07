using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntityManager;
using DataEntity;
using DTOs;
using AutoMapper;

namespace BusinessLogic
{
    public class MapperDto_Class
    {
        public static void ConfigAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {

                cfg.CreateMap<BaseClass, BaseDto>().MaxDepth(2);
                cfg.CreateMap<BaseDto, BaseClass>().MaxDepth(2);

                cfg.CreateMap<Student, StudentDto>().MaxDepth(2); 
                cfg.CreateMap<StudentDto, Student>().MaxDepth(2); 

                cfg.CreateMap<Marks, MarksDto>().MaxDepth(2);
                cfg.CreateMap<MarksDto, Marks>().MaxDepth(2);

            });
        }

    }
}
