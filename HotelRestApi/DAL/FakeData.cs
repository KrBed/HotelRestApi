using System;
using System.Collections.Generic;
using System.Linq;
using HotelApi.DAL;
using HotelRestApi.Models;

namespace HotelRestApi.DAL
{
    public class FakeData
    {
        public static void SeedData(HotelContext context)
        {
            var guests = new List<Guest>();
            var reservations = new List<Reservation>();

            guests.AddRange(new List<Guest>
            {
                new Guest
                {
                    FirstName = "Jacek", LastName = "Tarda", Email = "tarda@gmail.com", PostalCode = "10-234",
                    BirthDate = new DateTime(1978, 3, 9), Address = "Puszkina 9/1", City = "Olsztyn",
                    Telephone = "501144135"
                },
                new Guest
                {
                    FirstName = "Piotr", LastName = "Bukowiński", Email = "bukowinski@gmail.com", PostalCode = "11-400",
                    City = "Wrocław", Address = "Warszawska 33", Telephone = "601001001"
                },
                new Guest
                {
                    FirstName = "Piotr", LastName = "Gajko", Email = "piotrgajko@gmail.com", PostalCode = "10-900",
                    City = "Wrocław", Address = "Gdańska 13", Telephone = "666345456",
                    BirthDate = new DateTime(1967, 6, 19)
                },
                new Guest
                {
                    FirstName = "Patryk", LastName = "Wiśniewski", Email = "wisniewski@gmail.com",
                    PostalCode = "22-789", BirthDate = new DateTime(1995, 10, 11), City = "Warszawa",
                    Address = "Olszrtńska 34", Telephone = "223456789"
                },
                new Guest
                {
                    FirstName = "Krzysztof", LastName = "Malinowski", Email = "malinowski11@gmail.com",
                    PostalCode = "12-222", BirthDate = new DateTime(2000, 1, 22), City = "Gdańsk",
                    Address = "Płoskiego 6", Telephone = "514141414"
                },
                new Guest
                {
                    FirstName = "Marta", LastName = "Glinska", Email = "glinska@gmail.com", PostalCode = "11-400",
                    BirthDate = new DateTime(1985, 10, 7), City = "Suwałki", Address = "Mechaników 3",
                    Telephone = "84678456"
                },
                new Guest
                {
                    FirstName = "Marek", LastName = "Kapłon", Email = "m.kaplon@gmail.com", PostalCode = "80-678",
                    BirthDate = new DateTime(1940, 3, 30)
                },
                new Guest
                {
                    FirstName = "Tomek", LastName = "Wiśniewski", Email = "wisniewski@gmail.com", PostalCode = "10-700",
                    BirthDate = new DateTime(1985, 10, 9)
                },
                new Guest
                {
                    FirstName = "Jan", LastName = "Malinowski", Email = "malinowski@gmail.com", PostalCode = "15-240",
                    BirthDate = new DateTime(1986, 11, 1)
                },
                new Guest
                {
                    FirstName = "Piotr", LastName = "Wiśniewski", Email = "wisniewski@gmail.com", PostalCode = "12-670",
                    BirthDate = new DateTime(1990, 5, 19), City = "Warszawa", Address = "Poniatowskiego 16"
                },
                new Guest
                {
                    FirstName = "Marian", LastName = "Kolasiński", Email = "kowalski@gmail.com", PostalCode = "13-700",
                    BirthDate = new DateTime(1960, 4, 29)
                }
            });


            if (!context.Guests.Any()) context.Guests.AddRange(guests);

            reservations.AddRange(new List<Reservation>
                {
                    new Reservation
                    {
                        BookInDate = new DateTime(2020, 2, 24), BookOutDate = new DateTime(2020, 2, 26),
                        CreationDate = DateTime.Now, Currency = "PLN", Price = 160, ReservationCode = "9876543210",
                        Source = "Gotówka", Commission = 21
                    },
                    new Reservation
                    {
                        BookInDate = new DateTime(2020, 3, 12), BookOutDate = new DateTime(2020, 3, 16),
                        CreationDate = DateTime.Now, Currency = "PLN", Price = 240, ReservationCode = "147852369",
                        Source = "Gotówka", Commission = 30
                    },
                    new Reservation
                    {
                        BookInDate = new DateTime(2020, 4, 17), BookOutDate = new DateTime(2020, 4, 24),
                        CreationDate = DateTime.Now, Currency = "PLN", Price = 560, ReservationCode = "741258963",
                        Source = "Gotówka", Commission = 25
                    },
                    new Reservation
                    {
                        BookInDate = new DateTime(2020, 5, 23), BookOutDate = new DateTime(2020, 5, 30),
                        CreationDate = DateTime.Now, Currency = "PLN", Price = 640, ReservationCode = "9876543210",
                        Source = "Przelew", Commission = 28
                    },
                    new Reservation
                    {
                        BookInDate = new DateTime(2020, 6, 10), BookOutDate = new DateTime(2020, 6, 14),
                        CreationDate = DateTime.Now, Currency = "PLN", Price = 320, ReservationCode = "789654123",
                        Source = "Przelew", Commission = 10
                    },
                    new Reservation
                    {
                        BookInDate = new DateTime(2020, 7, 15), BookOutDate = new DateTime(2020, 7, 20),
                        CreationDate = DateTime.Now, Currency = "PLN", Price = 400, ReservationCode = "159847263",
                        Source = "Przelew", Commission = 11
                    },
                    new Reservation
                    {
                        BookInDate = new DateTime(2020, 8, 6), BookOutDate = new DateTime(2020, 8, 12),
                        CreationDate = DateTime.Now, Currency = "PLN", Price = 480, ReservationCode = "357421689",
                        Source = "Przelew", Commission = 16
                    },
                    new Reservation
                    {
                        BookInDate = new DateTime(2020, 9, 17), BookOutDate = new DateTime(2020, 9, 22),
                        CreationDate = DateTime.Now, Currency = "PLN", Price = 400, ReservationCode = "0002659000",
                        Source = "Karta płatnicza", Commission = 10
                    },
                    new Reservation
                    {
                        BookInDate = new DateTime(2020, 10, 19), BookOutDate = new DateTime(2020, 10, 21),
                        CreationDate = DateTime.Now, Currency = "PLN", Price = 160, ReservationCode = "7411596235",
                        Source = "Karta płatnicza", Commission = 18
                    },
                    new Reservation
                    {
                        BookInDate = new DateTime(2020, 11, 18), BookOutDate = new DateTime(2020, 11, 22),
                        CreationDate = DateTime.Now, Currency = "PLN", Price = 360, ReservationCode = "9871598472",
                        Source = "Karta płatnicza", Commission = 14
                    },
                    new Reservation
                    {
                        BookInDate = new DateTime(2020, 12, 20), BookOutDate = new DateTime(2020, 12, 24),
                        CreationDate = DateTime.Now, Currency = "PLN", Price = 360, ReservationCode = "1112223330",
                        Source = "Karta płatnicza", Commission = 10
                    },
                    new Reservation
                    {
                        BookInDate = new DateTime(2020, 3, 30), BookOutDate = new DateTime(2020, 4, 6),
                        CreationDate = DateTime.Now, Currency = "PLN", Price = 640, ReservationCode = "4488775219",
                        Source = "Karta płatnicza", Commission = 20
                    }
                }
            );
            if (!context.Reservations.Any()) context.Reservations.AddRange(reservations);

            context.SaveChanges();

            var random = new Random();

            foreach (var reservation in reservations)
            {
                var guestNum = random.Next(1, 3);
                var indexes = new List<int>();
                for (var i = 0; i <= guestNum ; i++)
                {
                    var index = random.Next(guests.Count);
                    if (!indexes.Contains(index))
                    {
                        indexes.Add(index);
                        var guest = guests[index];
                        guest.GuestReservations.Add(new ReservationGuest
                            { GuestId = guest.Id, ReservationId = reservation.Id });
                    }
                }
            }

            context.SaveChanges();
        }
    }
}