using HorseTrackingMobile.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using System.Text;

namespace HorseTrackingMobile.Database
{
    public class TemporaryAdding
    {
        public static List<User> AddUser()
        {
            return new List<User>()
            {
                new User()
                {
                    Id= 1,
                    Login="Karo",
                    Password="123",
                    Email="karo@gmail.com",
                    Name="Karolina",
                    Surname="Nowak"
                }
            };
        }

        //public static List<Horse> AddHorse()
        //{
        //    return new List<Horse>()
        //    {
        //        new Horse()
        //        {
        //            ID= 1,
        //            Name="Kasztan",
        //            Gender="Wałach",
        //            User=new User()
        //            {
        //                Id= 1,
        //                Login="Karo",
        //                Password="123",
        //                Email="karo@gmail.com",
        //                Name="Karolina",
        //                Surname="Nowak"
        //            },
        //            Status=new HorseStatus()
        //            {
        //                ID=1,
        //                Name="Active",
        //            }
        //        }
        //    };
        //}

        //public static List<Specialisation> AddDoctorSpecialisation()
        //{
        //    return new List<Specialisation>()
        //    {
        //        new Specialisation()
        //        {
        //            ID=1,
        //            Name="Weterynarz"
        //        }
        //    };
        //}

        //public static List<Doctor> AddDoctor()
        //{
        //    return new List<Doctor>()
        //    {
        //        new Doctor() {
        //            ID= 1,
        //            Firstname="Tomek",
        //            Specialisation=new Specialisation()
        //            {
        //                ID=1,
        //                Name="Weterynarz"
        //            }
        //        }
        //    };
        //}

        //public static List<Visit> AddVisit()
        //{
        //    return new List<Visit>()
        //    {
        //        new Visit()
        //        {
        //            ID= 1,
        //            Doctor= new Doctor()
        //            {
        //                ID= 1,
        //                Firstname="Tomek",
        //                Specialisation=new Specialisation()
        //                {
        //                    ID=1,
        //                    Name="Weterynarz"
        //                }
        //            },
        //            Horse=new Horse()
        //            {
        //                ID= 1,
        //                Name="Kasztan",
        //                Gender="Wałach",
        //                User=new User()
        //                {
        //                    Id= 1,
        //                    Login="Karo",
        //                    Password="123",
        //                    Email="karo@gmail.com",
        //                    Name="Karolina",
        //                    Surname="Nowak"
        //                },
        //                Status=new HorseStatus()
        //                {
        //                    ID=1,
        //                    Name="Active",
        //                }
        //            }

        //        }
        //    };
        //}

        //public static List<Activity> AddActivity()
        //{
        //    return new List<Activity>()
        //    {
        //        new Activity()
        //        {
        //            ID= 1,
        //            Date= DateTime.Now,
        //            Type=ActivityType.Grass,
        //        },
        //        new Activity()
        //        {
        //            ID= 2,
        //            Date= DateTime.Now.AddDays(1),
        //            Type=ActivityType.Grass,
        //        },
        //        new Activity()
        //        {
        //            ID= 3,
        //            Date= DateTime.Now.AddDays(2),
        //            Type=ActivityType.Grass,
        //        },
        //        new Activity()
        //        {
        //            ID= 4,
        //            Date= DateTime.Now.AddDays(3),
        //            Type=ActivityType.Grass,
        //        },
        //        new Activity()
        //        {
        //            ID= 5,
        //            Date= DateTime.Now.AddDays(4),
        //            Type=ActivityType.Grass,
        //        }
        //    };
        //}
    
    }
}
