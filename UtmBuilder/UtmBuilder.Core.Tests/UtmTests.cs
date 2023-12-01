using UtmBuilder.Core.ValueObjects;

namespace UtmBuilder.Core.Tests;

[TestClass]
public class UtmTests
{
    [TestMethod("Deve retornar uma Url de UTM")]
    [TestCategory("Teste de UTM")]
    public void ShouldReturnUrlFromUtm()
    {
        var url = new Url("https://balta.io/");
        var cmp = new Campaign("src","med","nme","id","ter","ctn");
        var utm = new Utm(url,cmp);

        var result = "https://balta.io/" +
                     "?utm_source=src" +
                     "&utm_medium=med" +
                     "&utm_campaign=nme" +
                     "&utm_id=id" +
                     "&utm_term=ter" +
                     "&utm_content=ctn";
        Assert.AreEqual(result, utm.ToString());
    }
}
