using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartBeauty.Models;


namespace SmartBeauty.Models
{
    public static class DbInitializer
    {
        public static void Initialize(Data.ApplicationDbContext context)
        {
            // context.Database.EnsureCreated();

            // Look for any Clients.
            if (context.Client.Any())
            {
                return;   // DB has been seeded
            }

            var clients = new Client[]
            {
            new Client{FirstName="Carson",LastName="Alexander",DateOfBirth=DateTime.Parse("2005-09-01")},
            new Client{FirstName="Meredith",LastName="Alonso",DateOfBirth=DateTime.Parse("2002-09-01")},
            new Client{FirstName="Arturo",LastName="Anand",DateOfBirth=DateTime.Parse("2003-09-01")},
            new Client{FirstName="Gytis",LastName="Barzdukas",DateOfBirth=DateTime.Parse("2002-09-01")},
            new Client{FirstName="Yan",LastName="Li",DateOfBirth=DateTime.Parse("2002-09-01")},
            new Client{FirstName="Peggy",LastName="Justice",DateOfBirth=DateTime.Parse("2001-09-01")},
            new Client{FirstName="Laura",LastName="Norman",DateOfBirth=DateTime.Parse("2003-09-01")},
            new Client{FirstName="Nino",LastName="Olivetto",DateOfBirth=DateTime.Parse("2005-09-01")}
            };
            foreach (Client c in clients)
            {
                context.Client.Add(c);
            }
            context.SaveChanges();

            var salons = new Salon[]
            {
            new Salon{SalonID=1050,SalonName="Chemistry"},
            new Salon{SalonID=4022,SalonName="Microeconomics"},
            new Salon{SalonID=4041,SalonName="Macroeconomics"},
            new Salon{SalonID=1045,SalonName="Calculus"},
            new Salon{SalonID=3141,SalonName="Trigonometry"},
            new Salon{SalonID=2021,SalonName="Composition"},
            new Salon{SalonID=2042,SalonName="Literature"}
            };
            foreach (Salon s in salons)
            {
                context.Salon.Add(s);
            }
            context.SaveChanges();

            var appointments = new Appointment[]
            //{
            //new Appointment{ClientID=1,SalonID=1050,BookingDate=DateTime.Parse("2021-05-01")},
            //new Appointment{ClientID=1,SalonID=4022,BookingDate=DateTime.Parse("2021-05-04")},
            //new Appointment{ClientID=1,SalonID=4041,BookingDate=DateTime.Parse("2021-05-02")},
            //new Appointment{ClientID=2,SalonID=1045,BookingDate=DateTime.Parse("2021-05-02")},
            //new Appointment{ClientID=2,SalonID=3141,BookingDate=DateTime.Parse("2021-05-02")},
            //new Appointment{ClientID=2,SalonID=2021,BookingDate=DateTime.Parse("2021-05-11")},
            //new Appointment{ClientID=3,SalonID=1050,BookingDate=DateTime.Parse("2021-05-12")},
            //new Appointment{ClientID=4,SalonID=1050,BookingDate=DateTime.Parse("2021-05-12")},
            //new Appointment{ClientID=4,SalonID=4022,BookingDate=DateTime.Parse("2021-05-03")},
            //new Appointment{ClientID=5,SalonID=4041,BookingDate=DateTime.Parse("2021-05-07")},
            //new Appointment{ClientID=6,SalonID=1045,BookingDate=DateTime.Parse("2021-05-03")},
            //new Appointment{ClientID=7,SalonID=3141,BookingDate=DateTime.Parse("2021-05-04")},
            //};
            //foreach (Appointment a in appointments)
            //{
            //    context.Appointment.Add(a);
            //}
            //context.SaveChanges();
            //var appointments = new Appointment[]
                {
                new Appointment {
                    ClientID = clients.Single(s => s.LastName == "Alexander").ClientID,
                    SalonID = salons.Single(c => c.SalonName == "Chemistry" ).SalonID,
                    BookingDate=DateTime.Parse("2021-05-01")
                },
                    new Appointment {
                    ClientID = clients.Single(s => s.LastName == "Alexander").ClientID,
                    SalonID = salons.Single(c => c.SalonName == "Microeconomics" ).SalonID,
                    BookingDate=DateTime.Parse("2021-05-01")
                    },
                    new Appointment {
                    ClientID = clients.Single(s => s.LastName == "Alexander").ClientID,
                    SalonID = salons.Single(c => c.SalonName == "Macroeconomics" ).SalonID,
                    BookingDate=DateTime.Parse("2021-05-01")
                    },
                    new Appointment {
                        ClientID = clients.Single(s => s.LastName == "Alonso").ClientID,
                    SalonID = salons.Single(c => c.SalonName == "Calculus" ).SalonID,
                    BookingDate=DateTime.Parse("2021-05-01")
                    },
                    new Appointment {
                        ClientID = clients.Single(s => s.LastName == "Alonso").ClientID,
                    SalonID = salons.Single(c => c.SalonName == "Trigonometry" ).SalonID,
                    BookingDate=DateTime.Parse("2021-05-01")
                    },
                    new Appointment {
                    ClientID = clients.Single(s => s.LastName == "Alonso").ClientID,
                    SalonID = salons.Single(c => c.SalonName == "Composition" ).SalonID,
                    BookingDate=DateTime.Parse("2021-05-01")
                    },
                    new Appointment {
                    ClientID = clients.Single(s => s.LastName == "Anand").ClientID,
                    SalonID = salons.Single(c => c.SalonName == "Chemistry" ).SalonID,
                    BookingDate=DateTime.Parse("2021-05-01")
                    },
                    new Appointment {
                    ClientID = clients.Single(s => s.LastName == "Anand").ClientID,
                    SalonID = salons.Single(c => c.SalonName == "Microeconomics").SalonID,
                    BookingDate=DateTime.Parse("2021-05-01")
                    },
                new Appointment {
                    ClientID = clients.Single(s => s.LastName == "Barzdukas").ClientID,
                    SalonID = salons.Single(c => c.SalonName == "Chemistry").SalonID,
                    BookingDate=DateTime.Parse("2021-05-01")
                    },
                    new Appointment {
                    ClientID = clients.Single(s => s.LastName == "Li").ClientID,
                    SalonID = salons.Single(c => c.SalonName == "Composition").SalonID,
                    BookingDate=DateTime.Parse("2021-05-01")
                    },
                    new Appointment {
                    ClientID = clients.Single(s => s.LastName == "Justice").ClientID,
                    SalonID = salons.Single(c => c.SalonName == "Literature").SalonID,
                    BookingDate=DateTime.Parse("2021-05-01")
                    }
};

            foreach (Appointment e in appointments)
            {
                var appointmentInDataBase = context.Appointment.Where(
                    s =>
                            s.Client.ClientID == e.ClientID &&
                            s.Salon.SalonID == e.SalonID).SingleOrDefault();
                if (appointmentInDataBase == null)
                {
                    context.Appointment.Add(e);
                }
            }
            context.SaveChanges();
 

    }
}
}
