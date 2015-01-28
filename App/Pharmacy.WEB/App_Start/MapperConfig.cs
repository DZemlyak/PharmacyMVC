using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Pharmacy.Core;
using Pharmacy.WEB.Core.ViewModels;

namespace Pharmacy.WEB
{
    public class MapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<Pharmacy.Core.Pharmacy, PharmacyViewModel>();
            Mapper.CreateMap<Order, OrderViewModel>();
            Mapper.CreateMap<Storage, StorageViewModel>();
            Mapper.CreateMap<Medcine, MedcineViewModel>();
            Mapper.CreateMap<Medcine, MedcineWithHistoryViewModel>();
            Mapper.CreateMap<MedcinePriceHistory, MedcinePriceHistoryViewModel>();
            Mapper.CreateMap<OrderDetails, OrderDetailedViewModel>();
            Mapper.CreateMap<Order, OrderDetailedViewModel>()
                .AfterMap((p,t) => t.OrderDetails = p.OrderDetailses);
            Mapper.CreateMap<OrderDetails, OrderDetailsViewModel>();

            Mapper.CreateMap<PharmacyViewModel, Pharmacy.Core.Pharmacy>();
            Mapper.CreateMap<MedcineViewModel, Medcine>()
                .BeforeMap((p,t) => t.MedcinePriceHistories.Add(new MedcinePriceHistory {
                    MedcineId = p.Id,
                    Price = t.Price,
                    PriceDate = DateTime.Now
                }));
            Mapper.CreateMap<StorageEditViewModel, Storage>()
                .ForMember(p => p.MedcineId, x => x.MapFrom(t => t.SelectedMedcineList))
                .ForMember(p => p.PharmacyId, x => x.MapFrom(t => t.SelectedPharmacyList))
                .ForMember(p => p.Count, x => x.MapFrom(t => t.Count));
            Mapper.CreateMap<OrderEditViewModel, Order>()
                .ForMember(p => p.Type, x => x.MapFrom(t => t.SelectedType))
                .ForMember(p => p.PharmacyId, x => x.MapFrom(t => t.SelectedPharmacyList));
            Mapper.CreateMap<OrderDetailsViewModel, OrderDetails>()
                .ForMember(p => p.MedcineId, x => x.MapFrom(t => t.MedcineId));
        }
    }
}