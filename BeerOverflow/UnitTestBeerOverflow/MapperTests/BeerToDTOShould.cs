using BeerOverflow.Data.Entities;
using BeerOverflow.Services.DTOs;
using BeerOverflow.Services.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.UnitTests.MapperTests
{
    [TestClass]
    public class BeerToDTOShould
    {
        [TestMethod]
        public void BeerToDTOShould_Succed_With_Rating_0() 
        {
            Country country = new Country
            {
                Id = Guid.Parse("0bab8f8f-0400-4573-9ddc-35850d47cb94"),
                Name = "Germany"
            };
            Brewery brewery = new Brewery
            {
                Id = Guid.Parse("0bab8f8f-0400-4573-9ddc-35850d47cb94"),
                Name = "Karlsberg"
            };
            Style style = new Style
            {
                Id = Guid.Parse("0bab8f8f-0400-4573-9ddc-35850d47cb94"),
                Name = "Green"
            };
            Beer beer = new Beer
            {
                Name = "Tuborg",
                CountryId = Guid.Parse("0bab8f8f-0400-4573-9ddc-35850d47cb94"), // The same as Germany Country Id
                StyleId = Guid.Parse("0e679a3c-5555-4a27-b0fa-594fba01ed68"), // The same as Style Id
                BreweryId = Guid.Parse("66dae4ad-753d-4170-90a7-5d58756b757f"), // The same as Karlsberg
                Country = country,
                Brewery = brewery,
                Style = style,
                ABV = 4.8,
            };
            BeerDTO expected = new BeerDTO
            {
                Name = "Tuborg",
                CountryId = Guid.Parse("0bab8f8f-0400-4573-9ddc-35850d47cb94"), // The same as Germany Country Id
                StyleId = Guid.Parse("0e679a3c-5555-4a27-b0fa-594fba01ed68"), // The same as Style Id
                BreweryId = Guid.Parse("66dae4ad-753d-4170-90a7-5d58756b757f"), // The same as Karlsberg
                CountryName = "Germany",
                BreweryName = "Karlsberg",
                StyleName = "Green",
                ABV = 4.8,
            };
            var result = beer.ToDTO();
            Assert.AreEqual(expected.Name, result.Name);
            Assert.AreEqual(expected.CountryId, result.CountryId);
            Assert.AreEqual(expected.CountryName, result.CountryName);
            Assert.AreEqual(expected.BreweryId, result.BreweryId);
            Assert.AreEqual(expected.BreweryName, result.BreweryName);
            Assert.AreEqual(expected.StyleId, result.StyleId);
            Assert.AreEqual(expected.StyleName, result.StyleName);
            Assert.AreEqual(expected.Rating, result.Rating);
            Assert.AreEqual(expected.ABV, result.ABV);
        }

    }
}
