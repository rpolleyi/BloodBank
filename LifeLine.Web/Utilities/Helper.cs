using AutoMapper;
using LifeLine.Core.Models;
using LifeLine.Infrastructure.Service;
using LifeLine.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LifeLine.Web.Utilities
{
    public class Helper
    {
        #region Mapping VM/M and M/VM
        /// <summary>
        /// Maps the DOnor ViewModel to the Donor model
        /// </summary>
        /// <param name="donorVM"></param>
        /// <returns></returns>
        public static Donor MapViewModelToModel(DonorVM donorVM)
        {
            return new LifeLine.Core.Models.Donor()
            {
                Id = donorVM.Id,
                FirstName = donorVM.FirstName,
                LastName = donorVM.LastName,
                PhoneNumber = donorVM.PhoneNumber,
                Email = donorVM.Email,
                DonationDate = donorVM.DonationDate,
                CampId = donorVM.CampId,
                AuditLogs = donorVM.AuditLogs,                
            };
        }

        /// <summary>
        /// Maps the DOnor Model to the Donor viewmodel
        /// </summary>
        /// <param name="donorVM"></param>
        /// <returns></returns>
        public static DonorVM MapModelToViewModel(Donor donor)
        {
            return new DonorVM()
            {
                Id = donor.Id,
                FirstName = donor.FirstName,
                LastName = donor.LastName,
                PhoneNumber = donor.PhoneNumber,
                Email = donor.Email,
                DonationDate = donor.DonationDate,
                CampId = donor.CampId,
                AuditLogs = donor.AuditLogs
            };
        }       

        #endregion
        
    }

    public static class Automap
    {
        /// <summary>
        /// Maps ViewModel to Model
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public static TModel MapViewModelToModel<TViewModel, TModel>(TViewModel viewModel)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TViewModel, TModel>();
                cfg.CreateMap<DonorVM, Donor>();
                cfg.CreateMap<CampVM, Camp>();
            });
            var mapper = config.CreateMapper();
            return mapper.Map<TModel>(viewModel);
        }

        /// <summary>
        /// Maps Model to ViewModel  
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static TViewModel MapModelToViewModel<TModel, TViewModel>(TModel model)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TModel, TViewModel>();
                cfg.CreateMap<Donor, DonorVM>();
                cfg.CreateMap<Camp, CampVM>();
            });
            var mapper = config.CreateMapper();
            return mapper.Map<TViewModel>(model);
        }
    }
}