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
    public static class ClubExtension
    {
        public static ClubEntity ConvertClubDTOToClubEntity(this ClubDTO c)
        {
            try
            {
                if (c != null)
                {
                    var club = new ClubEntity()
                    {
                        Id = c.Id,
                        Name = c.Name,

                    };
                    return club;
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }
    }
}
