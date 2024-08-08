using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.DTOs.Cours;
using Api.Model;

namespace Api.Mappers
{
    public static class CoursMappers
    {
       public static CoursDto ToCoursDto(this Cour courModel){
            return new CoursDto{
                Numcours = courModel.Numcours,
                Numclasse = courModel.Numclasse,
                Numenseignant = courModel.Numenseignant,
                Codematiere = courModel.Codematiere,
                Numsalle = courModel.Numsalle,
                Date = courModel.Date,
                Heuredebut = courModel.Heuredebut,
                Heurefin = courModel.Heurefin
            };
       } 

       public static Cour ToCoursFromCreate(this CreateCoursRequest coursRequest){
        return new Cour{
            Numclasse = coursRequest.Numclasse,
            Numenseignant = coursRequest.Numenseignant,
            Codematiere = coursRequest.Codematiere,
            Numsalle = coursRequest.Numsalle,
            Date = DateOnly.Parse(coursRequest.Date),
            Heuredebut = TimeOnly.Parse(coursRequest.Heuredebut),
            Heurefin = TimeOnly.Parse(coursRequest.Heurefin)
        };
       }
    }
}