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
    public static class PlayerExtension
    {
        public static PlayerEntity ConvertPlayerDTOToPlayerEntity(this PlayerDTO p)
        {
            try
            {
                if (p != null)
                {
                    var player = new PlayerEntity()
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Position = p.Position,
                        Age = p.Age,
                        Nationality = p.Nationality.FirstOrDefault()!,
                        Height = p.Height,
                        Foot = p.Foot ?? "Unknown",
                        Contract = p.Contract,
                        MarketValue = p.MarketValue,
                        JerseyNumber = p.JerseyNumber,
                        GoalsThisSeason = p.GoalsThisSeason,
                        AssistsThisSeason = p.AssistsThisSeason,
                        ImageURL = p.ImageURL  
                    };
                    return player;
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }


    }
}
