﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.PortableExecutable;
using System.Text;
using ParkingLot.Models;
using Xunit;

namespace ParkingLotTest
{
    public class Story6Test : IDisposable
    {
        private readonly List<Parkinglot> parkingLots = new List<Parkinglot> { new Parkinglot(1, 10), };
        private readonly Boy boy;
        private readonly SmartBoy smartBoy;
        private readonly SuperBoy superBoy;
        private readonly Manager manager = new Manager();

        public Story6Test()
        {
            boy = new Boy(1, parkingLots);
            smartBoy = new SmartBoy(2, parkingLots);
            superBoy = new SuperBoy(3, parkingLots);
        }

        public void Dispose()
        {
        }

        [Fact]
        public void AC1_Should_return_updated_managementList_when_add_parking_boys()
        {
            // given

            // when
            manager.AddBoy(boy);
            manager.AddBoy(smartBoy);
            manager.AddBoy(superBoy);
            var expected = new List<Boy>() { boy, smartBoy, superBoy, };
            var actual = manager.ManagementList;

            // then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AC1_Should_return_ticket_when_manager_call_boy_parking_car()
        {
            // given
            var car = new Car("BMW");

            // when
            manager.AddBoy(boy);
            manager.AddBoy(smartBoy);
            manager.AddBoy(superBoy);
            var ticket = manager.CallBoy(2).ParkCar(car);
            var expected = "0201001";
            var actual = ticket;

            // then
            Assert.Equal(expected, actual);
        }
    }
}
