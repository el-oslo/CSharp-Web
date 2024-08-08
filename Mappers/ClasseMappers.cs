using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.DTOs.Classe;
using Api.Model;

namespace Api.Mappers
{
    public static class ClasseMappers
    {
        public static ClasseDto ToClasseDto(this Classe classModel){
            return new ClasseDto {
                Numclasse = classModel.Numclasse,
                Niveau = classModel.Niveau,
                Parcours = classModel.Parcours
            };
        }
        public static Classe ToClasseFromCreate(this CreateClasseRequest classeReq){
            return new Classe{
                Numclasse = classeReq.Numclasse,
                Niveau = classeReq.Niveau,
                Parcours = classeReq.Parcours
            };
        }
    }
}