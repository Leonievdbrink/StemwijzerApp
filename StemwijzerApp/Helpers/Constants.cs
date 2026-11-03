using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StemwijzerApp.Helpers
{
    public static class Constants
    {
        // Android-emulator bereikt je pc via 10.0.2.2
        // Fysiek toestel: gebruik het LAN-IP van je pc, bv. http://192.168.1.20
        public static string BaseUrl =>
        DeviceInfo.Platform == DevicePlatform.Android
        ? "http://10.0.2.2/4s24-l9-pro-2-stemadvies-politieke-partij-DuBistBibble/api/"
        : "http://localhost/4s24-l9-pro-2-stemadvies-politieke-partij-DuBistBibble/api/";
    }
}
