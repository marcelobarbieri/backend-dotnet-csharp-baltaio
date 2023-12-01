﻿using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.Tests.ValueObjects;

[TestClass]
public class CampaignTests
{    
    [TestMethod("Teste de Campanha (DataRow)")]
    [TestCategory("Teste de Campanha")]
    [DataRow("", "", "", true)]
    [DataRow("", "", "name", true)]
    [DataRow("", "medium", "", true)]
    [DataRow("", "medium", "name", true)]
    [DataRow("source", "", "", true)]
    [DataRow("source", "", "name", true)]
    [DataRow("source", "medium", "",true)]
    [DataRow("source", "medium", "name",false)]
    public void TestCampaign(
        string source,
        string medium,
        string name,
        bool expectException)
    {
        if (expectException)
        {
            try
            {
                new Campaign(source,medium,name);
                Assert.Fail();
            }
            catch (InvalidCampaignException)
                //when (e.Message == "Source is invalid")
            {
                Assert.IsTrue(true);
            }
        }
        else
        {
            new Campaign(source, medium, name);
            Assert.IsTrue(true);
        }
    }
}
