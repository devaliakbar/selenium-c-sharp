using System.Diagnostics;
using System.Net;
using RestSharp;
using SeleniumCSharp.Models;
using Newtonsoft.Json;

namespace SeleniumCSharp.TestScripts.Zippopotam
{
    public class Zippopotam
    {
        private readonly RestClient client = new("http://api.zippopotam.us");

        [Test]
        [Author("Ali Akbar", "officialakbarali@gmail.com")]
        [Category("API Testing")]
        public void Test1()
        {
            PlaceModel place = GetPlace("de/bw/stuttgart");
            Assert.Multiple(() =>
            {
                Assert.That(place.Country, Is.EqualTo("Germany"));
                Assert.That(place.State, Is.EqualTo("Baden-Württemberg"));
            });
            var result = place!.SubPlaces!.Find(x => x.PostCode == "70597" && x.PlaceName == "Stuttgart Degerloch");
            Assert.That(result, Is.Not.EqualTo(null));
        }

        [Author("Ali Akbar", "officialakbarali@gmail.com")]
        [Category("API Testing")]
        [TestCase("us", "90210", "Beverly Hills")]
        [TestCase("us", "12345", "Schenectady")]
        [TestCase("ca", "B2R", "Waverley")]
        public void Test2(string country, string postalCode, string placeName)
        {
            PlaceModel place = GetPlace($"{country}/{postalCode}");
            var result = place!.SubPlaces!.Find(x => x.PlaceName == placeName);
            Assert.That(result, Is.Not.EqualTo(null));
        }

        private PlaceModel GetPlace(string path)
        {
            RestRequest request = new(path, Method.Get);

            var stopwatch = Stopwatch.StartNew();
            RestResponse response = client.Execute(request);
            stopwatch.Stop();

            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(response.ContentType, Is.EqualTo("application/json"));
                Assert.That(stopwatch.Elapsed.TotalSeconds, Is.LessThan(1.0));
            });

            return JsonConvert.DeserializeObject<PlaceModel>(response.Content!);
        }
    }
}

