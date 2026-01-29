using ZiekefondsReizen.Models;
using ZiekefondsReizen.ViewModels;

namespace ZiekefondsReizen.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<Groepsreis, HomeGroepsreisViewModel>()
                .ForMember(dest => dest.Datum, opt => opt.MapFrom(src => $"{src.Begindatum} - {src.Einddatum}"))
                .ForMember(dest => dest.Bestemming, opt => opt.MapFrom(src => src.Bestemming.Naam))
                .ForMember(dest => dest.Leeftijd, opt => opt.MapFrom(src => $"{src.Bestemming.MinLeeftijd} - {src.Bestemming.MaxLeeftijd} jaar"));

            CreateMap<Groepsreis, GroepsreisViewModel>()
                .ForMember(dest => dest.Bestemming, opt => opt.MapFrom(src => src.Bestemming.Naam));
            CreateMap<Groepsreis, GroepsreisDetailsViewModel>();
            CreateMap<Groepsreis, GroepsreisEditViewModel>();
            CreateMap<Groepsreis, GroepsreisDeleteViewModel>();
            CreateMap<GroepsreisCreateViewModel, Groepsreis>();
            CreateMap<GroepsreisEditViewModel, Groepsreis>();

            CreateMap<Activiteit, ActiviteitVieuwModel>();
            CreateMap<ActiviteitCreateViewModel, Activiteit > ();
            CreateMap<Activiteit, ActiviteitEditViewModel>();
            CreateMap<ActiviteitEditViewModel, Activiteit > ();
            CreateMap<Activiteit, ActiviteitDeleteViewModel>();
            CreateMap<Activiteit, ActiviteitDetailsViewModel>();

            CreateMap<Bestemming, BestemmingViewModel>()
                .ForMember(dest => dest.Leeftijd, opt => opt.MapFrom(src => $"van {src.MinLeeftijd} tot {src.MaxLeeftijd} jaar"));
            CreateMap<Bestemming, BestemmingDetailsViewModel>();
            CreateMap<Bestemming, BestemmingEditViewModel>();
            CreateMap<Bestemming, BestemmingDeleteViewModel>()
                .ForMember(dest => dest.Leeftijd, opt => opt.MapFrom(src => $"van {src.MinLeeftijd} tot {src.MaxLeeftijd} jaar")); ;
            CreateMap<BestemmingCreateViewModel, Bestemming>();
            CreateMap<BestemmingEditViewModel, Bestemming>();


            CreateMap<Kind, KindViewModel>();
            CreateMap<KindCreateViewModel, Kind>();
            CreateMap<Kind, KindEditViewModel>();
            CreateMap<KindEditViewModel, Kind>();
            CreateMap<Kind,KindDeleteViewModel>();
            CreateMap<Kind, KindDetailsViewModel>()
                .ForMember(dest => dest.Naam, opt => opt.MapFrom(src => $"{src.Voornaam} {src.Naam}"))
                .ForMember(dest => dest.Geboorte, opt => opt.MapFrom(src => $"{src.Geboortedatum} ( {DateTime.Today.Year - src.Geboortedatum.Year} jaar)"));

            CreateMap<Opleiding, OpleidingViewModel>();
            CreateMap<Opleiding, OpleidingDetailsViewModel>();
            CreateMap<Opleiding, OpleidingEditViewModel>();
            CreateMap<Opleiding, OpleidingDeleteViewModel>();
            CreateMap<OpleidingCreateViewModel, Opleiding>();
            CreateMap<OpleidingEditViewModel, Opleiding>();


	        CreateMap<Onkosten, OnkostenViewModel>();
            CreateMap<Onkosten, OnkostenDetailsViewModel>();
            CreateMap<OnkostenCreateViewModel, Onkosten>();
            CreateMap<Onkosten, OnkostenEditViewModel>();
            CreateMap<OnkostenEditViewModel, Onkosten>();
            CreateMap<Onkosten, OnkostenDeleteViewModel>();


            //CreateMap<Account, AccountViewModel>();
            //CreateMap<AccountCreateViewModel, Account>();
            //CreateMap<Account, AccountEditViewModel>();
            //CreateMap<AccountEditViewModel, Account>();
            //CreateMap<Account, AccountDeleteViewmodel>();
            //CreateMap<Account, AccountDetailsViewModel>();


            CreateMap<Deelnemer, DeelnemerViewModel>();
            CreateMap<DeelnemerViewModel, Deelnemer>();


            CreateMap<Review, ReviewViewModel>();
            CreateMap<Review, ReviewDetailsViewModel>();
            CreateMap<Review, ReviewDeleteViewModel>();
            CreateMap<ReviewCreateViewModel, Review>();

        }
    }
}
