using ForestApp_CityApi_Entity;
using ForestApp_CityApi_Entity.Configuration;
using ForestApp_CityApi_Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ForestApp_CityApi_DataAccess
{
    public class CityApiDbContext:DbContext
    {
        String[] eskisehir = new String[] { "Çifteler", "Mahmudiye", "Mihalıççık", "Sarıcakaya", "Seyitgazi", "Sivrihisar", "Alpu", "Beylikova", "İnönü", "Günyüzü", "Han", "Mihalgazi", "Odunpazarı", "Tepebaşı" };
        String[] bursa = new String[] { "Gemlik", "İnegöl", "İznik", "Karacabey", "Keles", "Mudanya", "Mustafakemalpaşa", "Orhaneli", "Orhangazi", "Yenişehir / Bursa", "Büyükorhan", "Harmancık", "Nilüfer", "Osmangazi", "Yıldırım", "Gürsu", "Kestel" };
        String[] ankara = new String[] {"Ayaş","Bala","Beypazarı","Çamlıdere","Çankaya","Çubuk","Elmadağ","Güdül","Haymana","Kalecik","Kızılcahamam","Nallıhan","Polatlı","Şereflikoçhisar","Yenimahalle", "Gölbaşı","Keçiören", "Mamak","Sincan", "Kazan","Akyurt","Etimesgut","Evren","Pursaklar" };
        String[] antalya = new String[] { "Akseki", "Alanya", "Elmalı", "Finike", "Gazipaşa", "Gündoğmuş", "Kaş", "Korkuteli", "Kumluca", "Manavgat", "Serik", "Demre", "İbradı", "Kemer / Antalya", "Aksu / Antalya", "Döşemealtı", "Kepez", "Konyaaltı", "Muratpaşa" };
        String[] istanbul = new String[] { "Adalar", "Bakırköy", "Beşiktaş", "Beykoz", "Beyoğlu", "Çatalca", "Eyüp", "Fatih", "Gaziosmanpaşa", "Kadıköy", "Kartal", "Sarıyer", "Silivri", "Şile", "Şişli", "Üsküdar", "Zeytinburnu", "Büyükçekmece", "Kağıthane", "Küçükçekmece", "Pendik", "Ümraniye", "Bayrampaşa", "Avcılar", "Bağcılar", "Bahçelievler", "Güngören", "Maltepe", "Sultanbeyli", "Tuzla", "Esenler", "Arnavutköy", "Ataşehir", "Başakşehir", "Beylikdüzü", "Çekmeköy", "Esenyurt", "Sancaktepe", "Sultangazi" };
        String[] izmir = new String[] { "Aliağa", "Bayındır", "Bergama", "Bornova", "Çeşme", "Dikili", "Foça", "Karaburun", "Karşıyaka", "Kemalpaşa / İzmir", "Kınık", "Kiraz", "Menemen", "Ödemiş", "Seferihisar", "Selçuk", "Tire", "Torbalı", "Urla", "Beydağ", "Buca", "Konak", "Menderes", "Balçova", "Çiğli", "Gaziemir", "Narlıdere", "Güzelbahçe", "Bayraklı", "Karabağlar" };
        String[] cities = new String[] {   "Ankara", "Antalya", "İstanbul","İzmir","Bursa","Eskişehir" };
        List<City> citiesList = new List<City>();
        List<District> districtsList = new List<District>();
        List<DistrictAndCityModel> districtAndCities = new List<DistrictAndCityModel>();
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=ForestAppDb;Trusted_Connection=True;");
        }
        //     public CityAppDbContext(DbContextOptions<CityAppDbContext> options)
        //: base(options)
        //     {
        //     }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            //modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.Entity<District>()
                .HasOne(d => d.City)
                .WithMany(c => c.Districts)
                 .HasForeignKey(d => d.CityId).OnDelete(DeleteBehavior.Cascade);
            foreach (var item in cities)
            {
                var id = Guid.NewGuid();
                citiesList.Add(new City() { Id = id, Name = item });
                List<string> list = new List<string>();
                switch (item)
                {
                    case "Ankara":
                        list.AddRange(ankara);
                        break;
                    case "Antalya":
                        list.AddRange(antalya);
                        break;
                    case "İstanbul":
                        list.AddRange(istanbul);
                        break;
                    case "İzmir":
                        list.AddRange(izmir);
                        break;
                    case "Bursa":
                        list.AddRange(bursa);
                        break;
                    case "Eskişehir":
                        list.AddRange(eskisehir);
                        break;
                    default:
                        break;
                }
                districtAndCities.Add(new DistrictAndCityModel() { CityName = id, DistrictName =list });
            }
            modelBuilder.Entity<City>().HasData(citiesList);
            foreach (var item in districtAndCities)
            {
                foreach (var Subitem in item.DistrictName)
                {
                    districtsList.Add(new District() { Id=Guid.NewGuid(), CityId = item.CityName, Name = Subitem });
                }
            }
            modelBuilder.Entity<District>().HasData(districtsList);


            //  modelBuilder.Entity<Book>().HasData(
            //    new Book { BookId = 1, AuthorId = 1, Title = "Hamlet" },
            //    new Book { BookId = 2, AuthorId = 1, Title = "King Lear" },
            //    new Book { BookId = 3, AuthorId = 1, Title = "Othello" }
            //);
        }
    }
}
