using Infrastructure.Models.Entities;
using Infrastructure.Models.TransfermarktAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ExtensionMethods
{
    public static class CompetitionExtension
    {
        public static CompetitionEntity ConvertCompetitionDTOToCompetitionEntity(this CompetitionDTO c)
        {
            try
            {
                if (c != null)
                {
                    var competition = new CompetitionEntity()
                    {
                        Id = c.Id,
                        Name = c.Name,
                       
                    };
                    return competition;
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }





    }
}
