using AdvertisingBillboard.Domain;
using Microsoft.AspNetCore.Mvc;


namespace AdvertisingBillboard.Web.Controllers
{
    public class VideosController : Controller
    {
        private readonly IVideosRepository _videosRepository;
        private readonly IDevicesRepository _devicesRepository;

        public VideosController(IVideosRepository videosRepository, IDevicesRepository devicesRepository) {
            _videosRepository = videosRepository;
            _devicesRepository = devicesRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Upload(string videoAddress, string videoName, string deviceName)
        {
            var device = _devicesRepository.Get(deviceName);
            Video video = new Video
            {
                Name = videoName,
                Address = videoAddress,
                Device = device
            };

            _videosRepository.Create(video);
            return Redirect("/Admin/Index");
        }


        [HttpPost]
        [ActionName("delete")]
        public RedirectResult Delete(string name)
        {
            _videosRepository.Delete(_videosRepository.Get(name));
            return Redirect("/Admin/Index");
        }
    }
}
