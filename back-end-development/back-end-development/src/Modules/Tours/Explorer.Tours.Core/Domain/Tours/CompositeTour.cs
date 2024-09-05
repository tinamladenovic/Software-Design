using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Tours.API.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain.Tours
{
    public class CompositeTour : Entity
    {
        public long TouristId { get; init; }
        public string Name { get; init; } = string.Empty;


        public List<Tour> Tours { get; init; } = new List<Tour>();
        public Difficult Difficult
        {
            get
            {
                var difficultyValues = Tours.Select(t => (int)t.Difficult).ToList();
                var middleValue = difficultyValues.Count > 0 ? (Difficult)((int)Math.Round(difficultyValues.Sum() / (double)difficultyValues.Count)) : Difficult.EASY;
                return middleValue;
            }
        }
        public double Distance
        {
            get
            {
                return Math.Round(Tours.Sum(t => t.Distance),2);
            }
        }

        [NotMapped]
        public List<Equipment> Equipments
        {
            get
            {
                return Tours.SelectMany(t => t.TourEquipment).Distinct().ToList();
            }
        }

        [NotMapped]
        public List<Checkpoint> Checkpoints
        {
            get
            {
                return Tours.SelectMany(t => t.Checkpoints).Distinct().ToList();
            }
        }

        public CompositeTour(long touristId, string name)
        {
            if(string.IsNullOrEmpty(name)) throw new ArgumentNullException("name");
            if (touristId == 0) throw new ArgumentException("tourist id");
            TouristId = touristId;
            Name = name;
        }

        public CompositeTour()
        {
            
        }
    }
}
