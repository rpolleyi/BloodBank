﻿using LifeLine.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LifeLine.Web.ViewModel
{
    public class CampVM
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(Utilities.Constants.CampContants.CAMP_NAME_LENGTH)]
        public string Name { get; set; }

        [Required]
        [StringLength(Utilities.Constants.CampContants.WHERE_LENGTH)]
        public string Where { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string When { get; set; }

        [NotMapped]
        public virtual List<Donor> Donors { get; set; }

        #region Mapping VM/M and M/VM

        public static Camp MapViewModelToModel(CampVM campVM)
        {
            return new LifeLine.Core.Models.Camp()
            {
                Id = campVM.Id,
                Name = campVM.Name,
                Where = campVM.Where,
                When = campVM.When
            };
        }

        public static CampVM MapModelToViewModel(Camp camp)
        {
            return new CampVM()
            {
                Id = camp.Id,
                Name = camp.Name,
                Where = camp.Where,
                When = camp.When
            };
        }

        #endregion
    }
}