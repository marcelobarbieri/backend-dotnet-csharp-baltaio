using UtmBuilder.Core.ValueObjects;

namespace UtmBuilder.Core.Tests;

[TestClass]
public class UtmTests
{
    private const string Result = "https://balta.io/" +
                                  "?utm_source=src" +
                                  "&utm_medium=med" +
                                  "&utm_campaign=nme" +
                                  "&utm_id=id" +
                                  "&utm_term=ter" +
                                  "&utm_content=ctn";

    private readonly Url _url = new("https://balta.io/"); // target type, omite a classe antes do new
    private readonly Campaign _campaign =  new( // target type, omite a classe antes do new
        source: "src", 
        medium: "med", 
        name: "nme", 
        id: "id", 
        term: "ter", 
        content: "ctn");

    [TestMethod("Deve retornar uma Url de Utm")]
    [TestCategory("Teste de Utm")]
    public void ShouldReturnUrlFromUtm()
    {
        var utm = new Utm(_url,_campaign);

        Assert.AreEqual(Result, utm.ToString());
        Assert.AreEqual(Result, (string)utm);
    }

    [TestMethod("Deve retornar um Utm da Url")]
    [TestCategory("Teste de Utm")]
    public void ShouldReturnUtmFromUrl()
    {
        Utm utm = Result;
        Assert.AreEqual("https://balta.io/", utm.Url.Address);
        Assert.AreEqual("src", utm.Campaign.Source);
        Assert.AreEqual("med", utm.Campaign.Medium);
        Assert.AreEqual("nme", utm.Campaign.Name);
        Assert.AreEqual("id", utm.Campaign.Id);
        Assert.AreEqual("ter", utm.Campaign.Term);
        Assert.AreEqual("ctn", utm.Campaign.Content);
    }
}
